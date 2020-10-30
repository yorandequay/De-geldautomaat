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
    public partial class inlogScherm : Form
    {
        // Load neccessities.
        GlobalMethods globalMethods = new GlobalMethods();
        user user = new user();
        public inlogScherm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool loggedIn = user.loginAccount(bankTxb.Text, passTxb.Text);
            if (loggedIn)
            {
                globalMethods.SwitchForm(this, new gebruikerScherm());
            }
        }
    }
}
