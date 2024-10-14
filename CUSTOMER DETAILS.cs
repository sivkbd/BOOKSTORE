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
    public partial class CUSTOMER_DETAILS : Form
    {
        public CUSTOMER_DETAILS()
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
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void CUSTOMER_DETAILS_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CUSTOMER WHERE CUS_EMAILADDRESS = '" + textBox4.Text + "' ";
                OleDbDataReader RE = cmd.ExecuteReader();
                if (RE.Read())
                {
                    MessageBox.Show("EMAIL ADDRESS ALREADY EXISTS");
                }
                else
                {
                    RE.Close();
                    cmd.CommandText = "INSERT INTO CUSTOMER(CUS_NAME,CUS_SURNAME,CUS_HOMEADDRESS,CUS_CELLNUMBER,CUS_EMAILADDRESS,CUS_PK,CUS_USERNAME,CUS_PASSWORD)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox3.Text.ToString() + "','" + textBox4.Text + "','" + textBox8.Text.ToString() + "','" + textBox9.Text + "','" + textBox10.Text.ToString() + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Succesfully Registered");
                    Login fm = new Login();
                    fm.Show();
                    this.Hide();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: " + EX.Message);
            }
            CLEARMETHOD();
            
        }
    }
}
