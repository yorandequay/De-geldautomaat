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

namespace geldAutomaat
{
    public partial class gebruikerScherm : Form
    {
        GlobalMethods globalMethods = new GlobalMethods();
        user user = new user();
        public gebruikerScherm()
        {
            InitializeComponent();
            user.update();
            lblUsername.Text = "Welkom: " + GlobalMethods.LoginInfo.FirstName + " " + GlobalMethods.LoginInfo.LastName;
            lblBankNumber.Text = GlobalMethods.LoginInfo.BankNumber;
            balanceLbl.Text = "€ " + GlobalMethods.LoginInfo.Balance.ToString();
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            globalMethods.SwitchForm(this, new geldStorten());
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            globalMethods.SwitchForm(this, new geldOpnemen());
        }

        private void TransactionsBtn_Click(object sender, EventArgs e)
        {
            globalMethods.SwitchForm(this, new transacties());
        }
    }
}
