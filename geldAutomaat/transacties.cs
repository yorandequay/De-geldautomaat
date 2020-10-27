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
    public partial class transacties : Form
    {
        GlobalMethods globalMethods = new GlobalMethods();
        Connection connection = new Connection();
        public transacties()
        {
            InitializeComponent();
            transactionsDgv.DataSource = connection.getTransactions();
        }

        private void UserScreenBtn_Click(object sender, EventArgs e)
        {
            globalMethods.SwitchForm(this, new gebruikerScherm());
        }
    }
}
