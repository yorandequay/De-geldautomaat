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
    public class transaction
    {
        DataLayer dataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        // Updates the balance of the user and adds transactions to the database
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
    }
}
