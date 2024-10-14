using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BOOKSTORE
{
    public partial class CUSTOMER_INFORMATION : Form
    {
        public CUSTOMER_INFORMATION()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;



        public void CLEARMETHOD()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void CUSTOMER_INFORMATION_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }
        
       

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT CUS_NAME,CUS_SURNAME,CUS_HOMEADDRESS,CUS_CELLNUMBER,CUS_EMAILADDRESS,CUS_PK FROM CUSTOMER";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                DA.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch(Exception Y)
            {
                MessageBox.Show("ERROR: SHOW BUTTON "+ Y.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CUSTOMER SET CUS_NAME = '" + textBox1.Text + "', CUS_SURNAME = '" + textBox2.Text + "',CUS_HOMEADDRESS ='" + textBox7.Text + "' ,CUS_CELLNUMBER = '" + textBox3.Text + "' ,CUS_EMAILADDRESS = '" + textBox4.Text + "' WHERE CUS_PK = '" + textBox8.Text.ToString() + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception T)
            {
                MessageBox.Show("ERROR: UPDATED BUTTON "+ T.Message);
            }
            CLEARMETHOD();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM CUSTOMER WHERE CUS_PK = '" + textBox8.Text.ToString() + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception EX)
            {
                MessageBox.Show("ERROR: DELETE BUTTON"+ EX.Message );
            }
            CLEARMETHOD();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                EMPLOYEE_MENU M2 = new EMPLOYEE_MENU();
                M2.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: MENU BUTTON "+EX.Message);
            }
        }       
    }
}
