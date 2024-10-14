using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class EMPLOYEE_MENU : Form
    {
        public EMPLOYEE_MENU()
        {
            InitializeComponent();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BOOK1 BK = new BOOK1();
                BK.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO BOOK1 FORM " + EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CUSTOMER_INFORMATION CI = new CUSTOMER_INFORMATION();
                CI.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO CUSTOMER INFORMATION FORM"+ EX.Message);
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Login LOG = new Login();
                LOG.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO LOGIN FORM " + EX.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CATALOGUE CT = new CATALOGUE();
                CT.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO CATALOG FORM "+ EX.Message);
            }
        }

      
    }
}
