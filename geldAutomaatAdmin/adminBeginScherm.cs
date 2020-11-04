using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace geldAutomaatAdmin
{
    public partial class adminBeginScherm : Form
    {
        GlobalMethods globalMethods = new GlobalMethods();
        user user = new user();
        public adminBeginScherm()
        {
            InitializeComponent();
            userDgv.DataSource = user.getUsers();
            userDgv.Columns["userID"].Visible = false;
            userDgv.Columns["blocked"].Visible = false;
            searchCb.SelectedItem = "firstName";
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            user.addAcount(firstNameTxb.Text, lastNameTxb.Text, bankNumberTxb.Text, passwordTxb.Text);
            userDgv.DataSource = user.getUsers();
        }

        private void UserDgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int userID = Convert.ToInt32(userDgv.Rows[userDgv.CurrentRow.Index].Cells[0].Value.ToString());
            user.deleteUser(userID);
        }

        private void UserDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int userID = Convert.ToInt32(userDgv.Rows[userDgv.CurrentRow.Index].Cells[1].Value.ToString());
            string firstName = userDgv.Rows[userDgv.CurrentRow.Index].Cells[2].Value.ToString();
            string lastName = userDgv.Rows[userDgv.CurrentRow.Index].Cells[3].Value.ToString();
            string bankNumber = userDgv.Rows[userDgv.CurrentRow.Index].Cells[4].Value.ToString();
            bool blockedChk = Convert.ToBoolean(userDgv.Rows[userDgv.CurrentRow.Index].Cells[0].Value);
            user.updateUser(userID, firstName, lastName, bankNumber);
            user.blockUser(userID, blockedChk);
        }

        private void SearchTxb_TextChanged(object sender, EventArgs e)
        {
            (userDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(searchCb.SelectedItem.ToString() + " LIKE '%{0}%'", searchTxb.Text);
        }
    }
}
