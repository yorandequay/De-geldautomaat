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
            public static float Balance;
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
