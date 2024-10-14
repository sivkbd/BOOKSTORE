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
    public partial class CATALOGUE : Form
    {
        private List<string> CARTITEMS = new List<string>();


        public CATALOGUE()
        {
            InitializeComponent();

        }

        OleDbConnection conn;
        OleDbCommand cmd;

        string[] ImagePaths = {@"C:\Users\L4G2\Pictures\Camera Roll\old-books-436498_1280.jpg",
                                    @"C:\Users\L4G2\Pictures\Camera Roll\pexels-itfeelslikefilm-590493.jpg",
                                    @"C:\Users\L4G2\Pictures\Camera Roll\pexels-minan1398-694740.jpg"};






        private int currentIndex = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Interval = 100000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            pictureBox20.ImageLocation = ImagePaths[currentIndex];

            currentIndex++;
            if (currentIndex >= ImagePaths.Length)
            {
                currentIndex = 0;
            }

        }

        private void CATARLOGUE_Load(object sender, EventArgs e)
        {
            
            //this.WindowState = FormWindowState.Maximized;
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L4G2\Desktop\Book store app.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            timer1.Start();



            try
            {
                conn.Open();
                cmd = new OleDbCommand("SELECT * FROM BOOK", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                RichTextBox[] DESCRIBE = new RichTextBox[] { richTextBox1, richTextBox2, richTextBox3, richTextBox4, richTextBox5, richTextBox6, richTextBox7, richTextBox8, richTextBox9, richTextBox10 };
                Label[] price = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
                PictureBox[] PICTURES = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
                Button[] buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };

                int i = 0;
                while (reader.Read() && i < 10)
                {
                    string BOOKDESCRIPT = "Title : " + reader["BOOK_NAME"].ToString() + " \n" + Environment.NewLine + "DESCRIPTION: " + reader["BOOK_DESCRIPTION"].ToString() + " \n" + Environment.NewLine + "GENRE: " + reader["BOOK_GENRE"].ToString() + " \n" + Environment.NewLine + "AUTHOR: " + reader["BOOK_AUTHOR"].ToString() + " \n" + Environment.NewLine + "PUBLISHER: " + reader["BOOK_PUBLISHER"].ToString() + " \n" + Environment.NewLine + "PUBLISH DATE: " + reader["BOOK_PUBLISHDATE"].ToString() + " \n" + Environment.NewLine + "LANGUAGE: " + reader["BOOK_LANGUAGE"].ToString() + " \n" + Environment.NewLine + "ISBN: " + reader["BOOK_ISBNUMBER"].ToString();
                    string prices = "R" + reader["BOOK_PRICE"].ToString();
                    string picture = reader["BOOK_IMAGE"].ToString();
                    int stock = Convert.ToInt32(reader["BOOK_STOCK"].ToString());
                    string bookPK = reader["BOOK_PK"].ToString();

                    DESCRIBE[i].Text = BOOKDESCRIPT;
                    price[i].Text = prices;
                    PICTURES[i].Image = Image.FromFile(picture);

                    // Set the tag of the button to the BOOK_PK
                    if (buttons[i] != null)
                    {
                        buttons[i].Tag = bookPK;
                        buttons[i].Click += new EventHandler(AddToCartButton_Click); // Ensure this is properly set up
                        if (stock <= 0)
                        {
                            buttons[i].Enabled = true;
                        }
                    }

                    i++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:CHECK HERE " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string bookPK = button.Tag.ToString();
                AddToCart(bookPK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: TEST " + ex.Message);
            }
        }



        private void CATARLOGUE_FORMClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }



        private void AddToCart(string bookName)
        {
            OleDbTransaction transaction = null;

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close(); // Ensure connection is closed if already open
                }

                conn.Open();
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                // Fetch book details
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT BOOK_NAME, BOOK_PRICE, BOOK_AUTHOR,BOOK_PUBLISHER,BOOK_STOCK FROM BOOK WHERE BOOK_PK = ?";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("?", bookName);

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int stock = Convert.ToInt32(reader["BOOK_STOCK"]);
                    double price = Convert.ToDouble(reader["BOOK_PRICE"]);
                    string author = reader["BOOK_AUTHOR"].ToString();
                    string publisher = reader["BOOK_PUBLISHER"].ToString();

                    if (stock > 0)
                    {
                        reader.Close();

                        // Update stock
                        cmd.CommandText = "UPDATE BOOK SET BOOK_STOCK = BOOK_STOCK - 1 WHERE BOOK_PK = ?";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", bookName);
                        cmd.ExecuteNonQuery();

                        // Insert into CHECKOUT
                        cmd.CommandText = "INSERT INTO CHECKOUT (BOOK_NAME, BOOK_PRICE, BOOK_AUTHOR, BOOK_PUBLISHER, BOOK_STOCK) VALUES (?, ?, ?, ?, ?)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", bookName);
                        cmd.Parameters.AddWithValue("?", price);
                        cmd.Parameters.AddWithValue("?", author);
                        cmd.Parameters.AddWithValue("?", publisher);
                        cmd.Parameters.AddWithValue("?", stock);
                        cmd.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();

                        CARTITEMS.Add(bookName);
                        button19.Text = "Cart(" + CARTITEMS.Count + ")";
                    }
                    else
                    {
                        MessageBox.Show("Sorry, this book is out of stock.");
                        transaction.Rollback();
                    }
                }
                else
                {
                    MessageBox.Show("Book not found.");
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Rollback Error: " + rollbackEx.Message);
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }



        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 F = new Form1(CARTITEMS);
                F.Show();
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR: ERROR TO GO TO FORM1 FORM THE CHECKOUT FORM" + EX.Message);

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Login log = new Login();
                log.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        
      


    }
}
    

