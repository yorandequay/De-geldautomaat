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
    public partial class geldStorten : Form
    {
        transaction transaction = new transaction();
        GlobalMethods globalMethods = new GlobalMethods();
        public geldStorten()
        {
            InitializeComponent();
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            transaction.deposit(depositTxb.Text);
            globalMethods.SwitchForm(this, new gebruikerScherm());
        }

        private void DepositTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            globalMethods.OnlyNumbers(sender, e);
        }
    }
}
