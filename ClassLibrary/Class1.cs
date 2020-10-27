using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    // Activates the queries
    public class DataLayer
    {
        // Creates databaseConnection.
        private static string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=8269;database=geldautomaat;";
        private MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);

        // Public method used to query to database connection.
        public DataTable Query(string sql, Action<MySqlParameterCollection> addParameters)
        {
            // Creates result variable and opens a new command using the SQL string and database connection.
            var result = new DataTable();
            using (var command = new MySqlCommand(sql, databaseConnection))
            {
                // Add parameters to command and open database connection.
                addParameters(command.Parameters);
                databaseConnection.Open();
                // Loads database result using command's ExecuteReader, and loads it into the result variable, then closes the connection.
                result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
            }
            return result;
        }
    }
    // These are all the query based methods
    public class Connection
    {
        DataLayer dataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        // Voegt een account toe aan de database
        public void addAcount(string firstName, string lastName, string bankNumber, string password)
        {
            if (firstName == "" || lastName == "" || bankNumber == "" || password == "")
            {
                MessageBox.Show("U moet alle velden invullen om te registreren!");
            }
            else
            {
                try
                {
                    DataTable GetBankNumberUsers = dataLayer.Query("SELECT bankNumber FROM user WHERE bankNumber = @Banknumber;",
                        p =>
                        {
                            p.Add("@Banknumber", MySqlDbType.VarChar, 55).Value = bankNumber;
                        });

                    // Checks if user already exists in database. If it already exists, shows a MessageBox.
                    if (GetBankNumberUsers.Rows.Count <= 0)
                    {
                        // Generates a new salt and the string to be saved into database.
                        byte[] NewSalt = GlobalMethods.GetSalt();
                        string NewSaltString = Convert.ToBase64String(NewSalt);

                        // Generates a salted hash and the string to be saved into database. Password plaintext has to be converted to bytes array to be properly hashed with salt.
                        byte[] SaltedHash = GlobalMethods.GenerateSaltedHash(Encoding.UTF8.GetBytes(password), NewSalt);
                        string SaltedHashString = Convert.ToBase64String(SaltedHash);
                        // Inserts new account into database.
                        dataLayer.Query("INSERT INTO `user` (firstName, lastName, bankNumber, balance, role, password, password_salt) VALUES (@Firstname, @Lastname, @Banknumber, 0, 0, @Password ,@PasswordSalt);",
                        p =>
                        {
                            p.Add("@Firstname", MySqlDbType.VarChar, 55).Value = firstName;
                            p.Add("@Lastname", MySqlDbType.VarChar, 55).Value = lastName;
                            p.Add("@Banknumber", MySqlDbType.VarChar, 55).Value = bankNumber;
                            p.Add("@Password", MySqlDbType.VarChar, 255).Value = SaltedHashString;
                            p.Add("@PasswordSalt", MySqlDbType.VarChar, 255).Value = NewSaltString;
                        });
                        MessageBox.Show("Uw account is toegevoegd.");
                    }
                    else
                    {
                        MessageBox.Show("Een gebruiker met het bankrekeningnummer '" + bankNumber + "' bestaat al.");
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }
        // Checkt of een account in de database bestaat
        public bool loginAccount(string loginBankNumber, string loginPassword)
        {
            if (loginBankNumber == "" || loginPassword == "")
            {
                MessageBox.Show("Voer uw bankrekeningnummer en wachtwoord in!");
                return false;
            }
            else
            {
                try
                {
                    DataTable GetUsers = dataLayer.Query("SELECT * FROM user;", p => { });
                    if (GetUsers.Rows.Count >= 0 || GetUsers != null)
                    {
                        foreach (DataRow User in GetUsers.Select())
                        {
                            // Gets the salt byte array from the selected user.
                            string SaltString = (string)User["password_salt"];
                            byte[] Salt = Convert.FromBase64String(SaltString);

                            // Gets the user password hash byte array from the selected user.
                            string UserPasswordHashString = (string)User["password"];
                            byte[] UserPasswordHash = Convert.FromBase64String(UserPasswordHashString);

                            // Using the salt byte array from the selected user, generates a new salted hash with the typed in login password.
                            byte[] LoginPasswordHash = GlobalMethods.GenerateSaltedHash(Encoding.UTF8.GetBytes(loginPassword), Salt);

                            // Checks if the typed in username is the same username and compares the password hash from the database with the password hash from the typed in login password.
                            if (loginBankNumber == (string)User["bankNumber"] && GlobalMethods.CompareByteArrays(UserPasswordHash, LoginPasswordHash))
                            {
                                // Stores user information in global methods. In admin_supermarket it first checks if the value isn't null.
                                GlobalMethods.LoginInfo.UserID = (int)User["userID"];
                                GlobalMethods.LoginInfo.FirstName = (string)User["firstName"];
                                GlobalMethods.LoginInfo.LastName = (string)User["lastName"];
                                GlobalMethods.LoginInfo.BankNumber = (string)User["bankNumber"];
                                GlobalMethods.LoginInfo.Balance = (int)User["balance"];
                                GlobalMethods.LoginInfo.Role = (int)User["role"];
                                MessageBox.Show("U gegevens waren correct welkom " + (string)User["firstName"]);
                                return true;
                            }
                        }
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist."); // If no user matched the username and password combination.
                        return false;
                    }
                    else // If there are no results from the user query.
                    {
                        MessageBox.Show("Er ging iets mis met de verbinding.");
                        return false;
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }

        // Adds money to the users balance
        public void deposit(string depositAmount)
        {
            try
            {
                dataLayer.Query("UPDATE user SET balance = balance + @Balance WHERE userID = @UserID",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
                    p.Add("@Balance", MySqlDbType.Int32, 55).Value = Convert.ToInt32(depositAmount);
                });
                dataLayer.Query("INSERT INTO `transaction` (userID, transactionType, transactionAmount) VALUES (@UserID, @TransactionType, @TransactionAmount);",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
                    p.Add("@TransactionType", MySqlDbType.Int32, 55).Value = 1;
                    p.Add("@TransactionAmount", MySqlDbType.Int32, 55).Value = depositAmount;
                });
            }
            catch (Exception e) // Catches any errors.
            {
                MessageBox.Show("Error: " + e);
            }
        }

        // Retrieves the data of the logged in user again
        public void update()
        {
            DataTable GetUsers = dataLayer.Query("SELECT * FROM user;", p => { });
            if (GetUsers.Rows.Count >= 0 || GetUsers != null)
            {
                foreach (DataRow User in GetUsers.Select())
                {
                    if (GlobalMethods.LoginInfo.UserID == (int)User["UserID"])
                    {
                        // Stores user information in global methods. In admin_supermarket it first checks if the value isn't null.
                        GlobalMethods.LoginInfo.UserID = (int)User["userID"];
                        GlobalMethods.LoginInfo.FirstName = (string)User["firstName"];
                        GlobalMethods.LoginInfo.LastName = (string)User["lastName"];
                        GlobalMethods.LoginInfo.BankNumber = (string)User["bankNumber"];
                        GlobalMethods.LoginInfo.Balance = (int)User["balance"];
                        GlobalMethods.LoginInfo.Role = (int)User["role"];
                    }
                }
            }
            else
            {
                MessageBox.Show("Er ging iets mis met de verbinding.");
            }
        }
        // Retrieves all users
        public DataTable getUsers()
        {
            DataTable GetUsers = dataLayer.Query("SELECT userID, firstName, lastName, bankNumber FROM user",
            p =>
            {
            });
            return GetUsers;
        }
        // Retrieves the last 3 transactions of a specific user
        public DataTable getTransactions()
        {
            DataTable GetTransactions = dataLayer.Query("SELECT * FROM transaction WHERE userID = @UserID ORDER BY transactionID DESC LIMIT 3;",
            p =>
            {
                p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
            });
            return GetTransactions;
        }
        // Checks if user has already made 3 transactions today
        public void withdraw(string withdrawAmount)
        {
            try
            {


                DataTable getTransactions = dataLayer.Query("SELECT * FROM transaction WHERE userID = @UserID AND transactionType = @TransactionType AND date >= NOW() - INTERVAL 1 DAY ORDER BY transactionID DESC LIMIT 3;",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
                    p.Add("@TransactionType", MySqlDbType.Int32, 55).Value = 0;
                });
                if (getTransactions.Rows.Count >= 3)
                {
                    MessageBox.Show("U heeft vandaag al 3 transacties gemaakt wacht tot morgen" +
                        " voordat u uw volgende transactie kan maken");
                }
                else
                {
                    if (Convert.ToInt32(withdrawAmount) >= 500)
                    {
                        MessageBox.Show("U kan niet meer dan 500 euro opnemen");
                    }
                    else
                    {
                        dataLayer.Query("UPDATE user SET balance = balance - @Balance WHERE userID = @UserID",
                        p =>
                        {
                            p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
                            p.Add("@Balance", MySqlDbType.Int32, 55).Value = Convert.ToInt32(withdrawAmount);
                        });
                        dataLayer.Query("INSERT INTO `transaction` (userID, transactionType, transactionAmount) VALUES (@UserID, @TransactionType, @TransactionAmount);",
                        p =>
                        {
                            p.Add("@UserID", MySqlDbType.Int32, 55).Value = GlobalMethods.LoginInfo.UserID;
                            p.Add("@TransactionType", MySqlDbType.Int32, 55).Value = 0;
                            p.Add("@TransactionAmount", MySqlDbType.Int32, 55).Value = withdrawAmount;
                        });
                    }
                }
            }
            catch (Exception e) // Catches any errors.
            {
                MessageBox.Show("Error: " + e);
            }
        }
        // Deletes selected user in the database
        public void deleteUser(int userID)
        {
            try
            {
                dataLayer.Query("DELETE FROM user WHERE userID = @UserID;", 
                p => 
                {
                    p.Add("@UserID", MySqlDbType.Int32, 55).Value = userID;
                });
            }
            catch (Exception e) // Catches any errors
            {
                MessageBox.Show("Error: " + e);
            }
        }
        // Updates the data of user in the database
        public void updateUser(int userID, string firstName, string lastName, string bankNumber)
        {
            try
            {
                dataLayer.Query("UPDATE user SET firstName = @Firstname, lastName = @Lastname, bankNumber = @Banknumber WHERE userID = @UserID;",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int32, 55).Value = userID;
                    p.Add("@Firstname", MySqlDbType.VarChar, 55).Value = firstName;
                    p.Add("@Lastname", MySqlDbType.VarChar, 55).Value = lastName;
                    p.Add("@Banknumber", MySqlDbType.VarChar, 55).Value = bankNumber;
                });
            }
            catch (Exception e) // Catches any errors
            {
                MessageBox.Show("Error: " + e);
            }
        }
    }
     // These are the global methods that are used all around the solution
    public class GlobalMethods
    {
        // Used to store login session info.
        public static class LoginInfo
        {
            public static int UserID;
            public static string BankNumber;
            public static string FirstName;
            public static string LastName;
            public static int Balance;
            public static int Role;
            public static int transactionLimit = 0;
        }
        // Method for switching forms quickly.
        public void SwitchForm(Form previousForm, Form newForm)
        {
            previousForm.Hide();
            newForm.Show();
            newForm.Location = previousForm.Location;
        }

        internal void OnlyNumbers(KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        // Generates a random salt.
        public static byte[] GetSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }
        // Generates a salted hash based on plaintext and salt.
        public byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        // Checks if 2 byte arrays are the same. Used for comparing salted hashes.
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
        // Can only put numbers into textbox
        public void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // Searches the datagridview cells
       // public DataGridView Search(DataGridView userDgv)
    }
}
