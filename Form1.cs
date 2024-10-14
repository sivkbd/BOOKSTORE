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
    public partial class Form1 : Form
    {
        private List<string> cartItems;
        private OleDbConnection conn;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb";

        public Form1(List<string> items)
        {
            InitializeComponent();
            cartItems = items;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(connectionString);

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Book Name";
            dataGridView1.Columns[1].Name = "Author";
            dataGridView1.Columns[2].Name = "Publisher";
            dataGridView1.Columns[3].Name = "Price";

            dataGridView1.Rows.Clear();

            foreach (string bookId in cartItems)
            {
                if (!string.IsNullOrEmpty(bookId))
                {
                    string bName = GetBookDetail(bookId, "BOOK_NAME");
                    string bookAuthor = GetBookDetail(bookId, "BOOK_AUTHOR");
                    string bookPublisher = GetBookDetail(bookId, "BOOK_PUBLISHER");
                    double bookPrice = GetBookPrice(bookId);

                    dataGridView1.Rows.Add(bName, bookAuthor, bookPublisher, bookPrice);
                }
            }

            // Update labels after filling data grid
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            label4.Text = "Quantity: " + cartItems.Count;
            label6.Text = "Total Amount: " + calculateTotalAmount();
            label7.Text = "VAT: " + calculateVat();
        }

        private double calculateTotalAmount()
        {
            double totalAmount = 0.0;
            foreach (string bookId in cartItems)
            {
                totalAmount += GetBookPrice(bookId);
            }
            return totalAmount;
        }

        private double calculateVat()
        {
            double totalAmount = calculateTotalAmount();
            double vatRate = 0.15;
            return totalAmount * vatRate + calculateTotalAmount();
        }

        private string GetBookDetail(string bookId, string columnName)
        {
            string detail = "";
            try
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT BOOK_NAME,BOOK_AUTHOR,BOOK_PUBLISHER FROM BOOK WHERE BOOK_PK = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", bookId);
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detail = reader[columnName].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching {columnName}:" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return detail;
        }

        private double GetBookPrice(string bookId)
        {
            double price = 0.0;
            try
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT BOOK_PRICE FROM BOOK WHERE BOOK_PK = ?", conn))
                {
                    cmd.Parameters.AddWithValue("?", bookId);
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = Convert.ToDouble(reader["BOOK_PRICE"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching book price: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the cart items list
                cartItems.Clear();

                // Clear the DataGridView
                dataGridView1.Rows.Clear();

                // Update labels
                UpdateLabels();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR CLEARING THE CHECKOUT ITEM " + EX.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CONTACT_US CTU = new CONTACT_US();
                CTU.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: CONTACT US" + EX.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Order successful, Thank you for shopping with us");
                // Clear the cart items list
                cartItems.Clear();

                // Clear the DataGridView
                dataGridView1.Rows.Clear();

                // Update labels
                UpdateLabels();
                CATALOGUE CT = new CATALOGUE();
                CT.Show();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: PROCCEED TO PAY ERROR" + EX.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string bookName = row.Cells["Book Name"].Value.ToString(); // Ensure this matches your column name

                        // Remove the corresponding item from cartItems
                        cartItems.Remove(bookName); // Directly remove the string item

                        // Remove the row from the DataGridView
                        dataGridView1.Rows.RemoveAt(row.Index);
                    }

                    // Update UI labels
                    UpdateLabels();
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Unable to delete item. " + ex.Message);
            }
        }

    }
}










    /*public partial class Form1 : Form
    {
        private List<string> cartItems;

        public Form1(List<string> items)
        {
            InitializeComponent();
            cartItems = items;
        }
        OleDbConnection conn;
        OleDbCommand cmd;
        public double price = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;

            
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Book Name";
                dataGridView1.Columns[1].Name = "Author";
                dataGridView1.Columns[2].Name = "Publisher";
                dataGridView1.Columns[3].Name = "Price";

                dataGridView1.Rows.Clear();
                foreach (string BOOKS in cartItems)
                {
                    if (!string.IsNullOrEmpty(BOOKS))
                    {
                        string bName = GetBookName(BOOKS);
                        string bookAuthor = GetBookAuthor(BOOKS);
                        string bookPublisher = GetBookPublisher(BOOKS);
                        double bookPrice = GetBookPrice(BOOKS);
                        dataGridView1.Rows.Add(bName, bookAuthor, bookPublisher, bookPrice);
                        // Fetch item details from database to calculate totalAmount
                        label4.Text = "Quantity: " + cartItems.Count;
                        label6.Text = "Total Amount: " + calculateTotalamount();
                        label7.Text = "VAT: " + calculatevat();

                    }
                }

            
        }
        private double calculateTotalamount()
        {
            double totalAmount = 0.0; // Calculate total amount based on cartItems
            foreach (string bookName in cartItems)
            {
                double bookPrice = GetBookPrice(bookName);
                totalAmount += bookPrice;
            }
            return totalAmount;

        }
        private double calculatevat()
        {
            double totalAmount1 = calculateTotalamount();
            double totalAmount2 = 0.15;
            double AMOUNT = totalAmount2 * totalAmount1;
            return AMOUNT + calculateTotalamount();

        }
        private string GetBookName(string BOOKS)
        {
            string Bname = "";
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT BOOK_NAME FROM BOOK WHERE BOOK_PK = @BOOK_PK";
                cmd.Parameters.AddWithValue("@BOOK_PK", BOOKS);
                OleDbDataReader READ = cmd.ExecuteReader();
                if (READ.Read())
                {
                    Bname = READ["BOOK_NAME"].ToString();
                    return Bname;

                }
                READ.Close();
                conn.Close();
            }
            catch(Exception y)
            {
                MessageBox.Show("error: 2"+y.Message);
            }
            return Bname;
        }
        private string GetBookPublisher(string BOOKS)
        {
            string publisher = "";
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT BOOK_PUBLISHER FROM BOOK WHERE BOOK_PK = @BOOK_PK";
                cmd.Parameters.AddWithValue("@BOOK_PK", BOOKS);
                OleDbDataReader READ = cmd.ExecuteReader();
                if (READ.Read())
                {
                    publisher = READ["BOOK_PUBLISHER"].ToString();
                    return publisher;

                }
                READ.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("error: 3"+ e.Message);
            }
            return publisher;

        }
        private string GetBookAuthor(string BOOKS)
        {
            string author = "";

            try
            {
                //string author = "";
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT BOOK_AUTHOR FROM BOOK WHERE BOOK_PK = @BOOK_PK";
                cmd.Parameters.AddWithValue("@BOOK_PK", BOOKS);
                OleDbDataReader READ = cmd.ExecuteReader();
                if (READ.Read())
                {
                    author = READ["BOOK_AUTHOR"].ToString();
                    return author;

                }
                READ.Close();
                conn.Close();

            }
            catch(Exception TE)
            {
                MessageBox.Show("ERROR: 4" + TE.Message);
            }
            return author;

        }
        private double GetBookPrice(string BOOKS)
        {
           
            try
            {
                //double price = 0;
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT BOOK_PRICE FROM BOOK WHERE BOOK_PK = @BOOK_PK";
                cmd.Parameters.AddWithValue("@BOOK_PK", BOOKS);
                OleDbDataReader READ = cmd.ExecuteReader();
                if (READ.Read())
                {
                    price = Convert.ToDouble(READ["BOOK_PRICE"]);
                    return price;

                }
                READ.Close();
                conn.Close();
            }

            catch (Exception t)
            {
                MessageBox.Show("error: 5" + t.Message);

            }
            return price;
        }
    }
}*/





