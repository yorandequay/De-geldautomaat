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
        Connection connection = new Connection();
        public inlogScherm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool loggedIn = connection.loginAccount(bankTxb.Text, passTxb.Text);
            if (loggedIn)
            {
                globalMethods.SwitchForm(this, new gebruikerScherm());
            }
        }
    }
}
