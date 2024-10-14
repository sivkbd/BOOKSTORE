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
    public partial class BOOK1 : Form
    {

        public BOOK1()
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
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox13.Clear();
        }
        private void BOOK1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Check if the book already exists
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM BOOK WHERE BOOK_PK = ?", conn);
                cmd.Parameters.AddWithValue("@BOOK_PK", textBox10.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("BOOK PRIMARY KEY ALREADY EXISTS");
                }
                else
                {
                    // Insert new book into BOOK table
                    cmd.CommandText = "INSERT INTO BOOK (BOOK_NAME, BOOK_DESCRIPTION, BOOK_GENRE, BOOK_PRICE, BOOK_AUTHOR, BOOK_QUANTITY, BOOK_PUBLISHER, BOOK_PUBLISHDATE, BOOK_ISBNUMBER, BOOK_LANGUAGE, BOOK_PK, BOOK_IMAGE,BOOK_STOCK) " +
                                      "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BOOK_NAME", textBox2.Text);
                    cmd.Parameters.AddWithValue("@BOOK_DESCRIPTION", textBox3.Text);
                    cmd.Parameters.AddWithValue("@BOOK_GENRE", textBox4.Text);
                    cmd.Parameters.AddWithValue("@BOOK_PRICE", textBox5.Text);
                    cmd.Parameters.AddWithValue("@BOOK_AUTHOR", textBox6.Text);
                    cmd.Parameters.AddWithValue("@BOOK_QUANTITY", textBox7.Text); // Set stock count
                    cmd.Parameters.AddWithValue("@BOOK_PUBLISHER", textBox9.Text);
                    cmd.Parameters.AddWithValue("@BOOK_PUBLISHDATE", textBox8.Text);
                    cmd.Parameters.AddWithValue("@BOOK_ISBNUMBER", textBox11.Text);
                    cmd.Parameters.AddWithValue("@BOOK_LANGUAGE", textBox1.Text);
                    cmd.Parameters.AddWithValue("@BOOK_PK", textBox10.Text);
                    cmd.Parameters.AddWithValue("@BOOK_IMAGE", @"C:\Users\L4G2\Downloads\" + textBox13.Text);
                    cmd.Parameters.AddWithValue("@BOOK_STOCK", textBox7.Text); // Set stock
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("BOOK ADDED SUCCESSFULLY, CLICK SHOW TO REFRESH THE LIST");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:add button " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            CLEARMETHOD();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE BOOK SET BOOK_NAME = ?, BOOK_DESCRIPTION = ?, BOOK_GENRE = ?, BOOK_PRICE = ?, BOOK_AUTHOR = ?, BOOK_QUANTITY = ?, BOOK_PUBLISHER = ?, BOOK_PUBLISHDATE = ?, BOOK_ISBNUMBER = ?, BOOK_LANGUAGE = ?, BOOK_STOCK = ? WHERE BOOK_PK = ?";
                cmd.Parameters.AddWithValue("@BOOK_NAME", textBox2.Text);
                cmd.Parameters.AddWithValue("@BOOK_DESCRIPTION", textBox3.Text);
                cmd.Parameters.AddWithValue("@BOOK_GENRE", textBox4.Text);
                cmd.Parameters.AddWithValue("@BOOK_PRICE", textBox5.Text);
                cmd.Parameters.AddWithValue("@BOOK_AUTHOR", textBox6.Text);
                cmd.Parameters.AddWithValue("@BOOK_QUANTITY", textBox7.Text); // Update stock count
                cmd.Parameters.AddWithValue("@BOOK_PUBLISHER", textBox9.Text);
                cmd.Parameters.AddWithValue("@BOOK_PUBLISHDATE", textBox8.Text);
                cmd.Parameters.AddWithValue("@BOOK_ISBNUMBER", textBox11.Text);
                cmd.Parameters.AddWithValue("@BOOK_LANGUAGE", textBox1.Text);
                cmd.Parameters.AddWithValue("@BOOK_STOCK", textBox7.Text); // Update stock
                cmd.Parameters.AddWithValue("@BOOK_PK", textBox10.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("BOOK UPDATED SUCCESSFULLY, CLICK SHOW TO REFRESH THE LIST");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:update button " + ex.Message);
            }
            finally
            {
                conn.Close();
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
                cmd.CommandText = "DELETE FROM BOOK WHERE BOOK_PK = '"+textBox10.Text+"'";
                //cmd.Parameters.AddWithValue("@BOOK_PK", textBox10.Text); // Assuming you want to delete by PK
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("BOOK DELETED SUCCESSFULLY, CLICK SHOW TO REFRESH THE LIST");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:delete button " + ex.Message);
            }
            CLEARMETHOD();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM BOOK";
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                DA.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:show button " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                CATALOGUE CT = new CATALOGUE();
                CT.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO CATALOG FORM"+ EX.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLOYEE_MENU m = new EMPLOYEE_MENU();
                m.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro: back button"+ ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM BOOK WHERE BOOK_NAME = @bookName";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookName", textBox12.Text);

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Book found, show that specific book in DataGridView
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("The book is not available");
                            dataGridView1.DataSource = null; // Clear previous data
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}
                    
                      
    