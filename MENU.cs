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
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLOYEE EMP = new EMPLOYEE();
                EMP.Show();
                this.Close();
            }
            catch(Exception EX)
            {
                MessageBox.Show("ERROR:" + EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CUSTOMER_INFORMATION CUS = new CUSTOMER_INFORMATION();
                CUS.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR" + EX.Message);
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
                MessageBox.Show("ERROR:"+EX.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BOOK1 b = new BOOK1();
                b.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: "+EX.Message);
            }

        }

      
    }
}
