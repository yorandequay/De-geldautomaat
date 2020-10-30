using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class user
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
}
