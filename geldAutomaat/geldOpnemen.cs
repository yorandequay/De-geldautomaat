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
    public partial class geldOpnemen : Form
    {
        Connection connection = new Connection();
        GlobalMethods globalMethods = new GlobalMethods();
        public geldOpnemen()
        {
            InitializeComponent();
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            connection.withdraw(withdrawTxb.Text);
            globalMethods.SwitchForm(this, new gebruikerScherm());
        }

        private void WithdrawTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            globalMethods.OnlyNumbers(sender, e);
        }
    }
}
