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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmd;

        public void CLEARMETHOD()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            label5.Font = new Font(label5.Font.FontFamily, 9);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                PRIVACYPOLICY P = new PRIVACYPOLICY();
                P.Show();
                this.Hide();
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message);
            }
            CLEARMETHOD();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error"+ ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT USERNAME, PASSWORD FROM LOGIN WHERE USERNAME ='" + textBox1.Text + "' AND PASSWORD = " + textBox2.Text.ToString() + "";
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("SUCCESSFULLY LOGGED IN");
                    MENU M = new MENU();
                    M.Show();
                    this.Hide();

                }
                else
                {

                    MessageBox.Show("INCORRECT PASSWORD AND USERNAME OR ACCESS DENIED");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
            CLEARMETHOD();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT CUS_USERNAME, CUS_PASSWORD FROM CUSTOMER WHERE CUS_USERNAME ='" + textBox1.Text + "' AND CUS_PASSWORD = " + textBox2.Text.ToString() + "";
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("CUSTOMER SUCCESSFULLY LOGGED IN");
                    CATALOGUE cat = new CATALOGUE();
                    cat.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("incorrect password or username, please try again");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
            CLEARMETHOD();

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button2.BackColor = Color.Transparent;
                button2.FlatStyle = FlatStyle.Flat;
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT EMP_USERNAME, EMP_PASSWORD FROM EMPLOYEE WHERE EMP_USERNAME ='" + textBox1.Text + "'  AND EMP_PASSWORD = " + textBox2.Text.ToString() + "";
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("successfully logged in");
                    EMPLOYEE_MENU EM = new EMPLOYEE_MENU();
                    EM.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("incorrect password or username, please try again");
                }

                conn.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("error: "+ a.Message);
            }
            CLEARMETHOD();

        }
        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                PRIVACYPOLICY pp = new PRIVACYPOLICY();
                this.Hide();
                pp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string input = textBox2.Text;

            // Check if the input contains only digits
            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"\D")) // \D matches any non-digit
            {
                label5.Text = "Password must contain only numbers!";
                label5.ForeColor = Color.Red;
                
            }
            else
            {
                label5.Text = ""; // Clear the message if valid
            }
        }

       
    }
}
