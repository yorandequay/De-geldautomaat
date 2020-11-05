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
            //userDgv.Columns["blocked"].Visible = false;
            searchCb.SelectedItem = "firstName";
            userDgv.CurrentCell = null;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            user.addAcount(firstNameTxb.Text, lastNameTxb.Text, bankNumberTxb.Text, passwordTxb.Text);
            userDgv.DataSource = user.getUsers();
            userDgv.CurrentCell = null;
        }

        private void UserDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            user.updateUser(GlobalMethods.SelectedRow.RowID, GlobalMethods.SelectedRow.FirstName,
                GlobalMethods.SelectedRow.LastName, GlobalMethods.SelectedRow.BankNumber);
        }

        private void SearchTxb_TextChanged(object sender, EventArgs e)
        {
            (userDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(searchCb.SelectedItem.ToString() + " LIKE '%{0}%'", searchTxb.Text);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            user.deleteUser(GlobalMethods.SelectedRow.RowID);
            userDgv.DataSource = user.getUsers();
            userDgv.CurrentCell = null;
        }

        private void UserDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalMethods.SelectedRow.RowID = Convert.ToInt32(userDgv.Rows[userDgv.CurrentRow.Index].Cells[0].Value.ToString());
            GlobalMethods.SelectedRow.FirstName = userDgv.Rows[userDgv.CurrentRow.Index].Cells[1].Value.ToString();
            GlobalMethods.SelectedRow.LastName = userDgv.Rows[userDgv.CurrentRow.Index].Cells[2].Value.ToString();
            GlobalMethods.SelectedRow.BankNumber = userDgv.Rows[userDgv.CurrentRow.Index].Cells[3].Value.ToString();
            GlobalMethods.SelectedRow.Blocked = Convert.ToInt32(userDgv.Rows[userDgv.CurrentRow.Index].Cells[4].Value.ToString());
        }

        private void BlockBtn_Click(object sender, EventArgs e)
        {
            user.blockUser(GlobalMethods.SelectedRow.RowID, GlobalMethods.SelectedRow.Blocked);
            userDgv.DataSource = user.getUsers();
            userDgv.CurrentCell = null;
        }

        private void AdminBeginScherm_Load(object sender, EventArgs e)
        {
            userDgv.CurrentCell = null;
        }
    }
}
