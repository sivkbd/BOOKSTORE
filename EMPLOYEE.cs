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
    public partial class EMPLOYEE : Form
    {
        public EMPLOYEE()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;

        private void EMPLOYEE_Load(object sender, EventArgs e)
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
                cmd.CommandText = "INSERT INTO EMPLOYEE(EMP_NAME,EMP_SURNAME,EMP_IDNUMBER,EMP_JOBTITLE,EMP_EMPLOYEECODE,EMP_PK,EMP_USERNAME,EMP_PASSWORD)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox6.Text + "','" + textBox7.Text.ToString() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception EX)
            {
                MessageBox.Show("ERROR: " + EX.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EMPLOYEE";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                DA.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception AZ)
            {
                MessageBox.Show("error: "+AZ.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE EMPLOYEE SET EMP_NAME = '" + textBox1.Text + "',EMP_SURNAME = '" + textBox2.Text + "',EMP_IDNUMBER = '" + textBox3.Text.ToString() + "',EMP_JOBTITLE = '" + textBox4.Text + "',EMP_EMPLOYEECODE = '" + textBox5.Text + "',EMP_USERNAME = '" + textBox6.Text + "',EMP_PASSWORD = '" + textBox7.Text.ToString() + "' WHERE EMP_PK = '" + textBox8.Text + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("error: "+ a.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM EMPLOYEE WHERE EMP_PK = '" + textBox8.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception r)
            {
                MessageBox.Show("error: " + r.Message );
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MENU M = new MENU();
            M.Show();
            this.Hide();
        }

        
       
    }
}
