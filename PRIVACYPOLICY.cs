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
    public partial class PRIVACYPOLICY : Form
    {
        public PRIVACYPOLICY()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "Terms and Conditions of Sale \n 1. Payment Terms: Payment is due at the time of purchase. We accept cash, credit cards (Visa, Mastercard, Amex), and debit cards. \n 2. Refund Policy: Returns are accepted within 30 days of purchase. Books must be in original condition. Refunds will be issued in original form of payment. \n 3. Price Policy: Prices are subject to change without notice. We reserve the right to limit quantities or cancel orders if books are out of stock or unavailable. \n 4. Availability: We strive to maintain accurate inventory levels, but sometimes books may be out of stock. We will notify you if a book is unavailable and offer alternatives or a refund. \n 5. Shipping: Shipping costs are calculated based on weight and destination. Delivery times are estimates and not guaranteed. \n 6. Discounts: Discounts apply to select titles only and cannot be combined with other offers. \n 7. Privacy Policy: We collect personal information for transaction purposes only and do not share with third parties. \n 8. Warranty: Books are sold as is and we disclaim all warranties, express or implied. \n 9. Governing Law: These terms and conditions are governed by [State/Country] law. \n 10. Changes: We reserve the right to modify these terms and conditions at any time without notice. \n Additional Terms \n - All sales are final on special orders and non-returnable items. \n - We reserve the right to cancel orders if we suspect fraud or unauthorized use. \n - Prices do not include taxes or shipping costs. \n - We are not responsible for damages or losses during shipping. \n\n POPIA (Protection of Personal Information Act) is a South African law that regulates the collection, use, and protection of personal information. \n\n Book Store POPIA Policy \n Introduction \n We, The Ideal Book Store , are committed to protecting the personal information of our customers, employees, and suppliers. This POPIA policy explains how we collect, use, and protect personal information in accordance with the Protection of Personal Information Act (POPIA). \n Types of Personal Information Collected \n - Customer information: name, contact details, address, phone number, email address \n - Employee information: name, ID number, address, phone number, email address \n - Supplier information: name, company name, contact details, address \n Purpose of Collection \n - To process customer orders and deliveries \n - To provide customer service and support \n - To manage employee relationships and benefits \n - To facilitate supplier transactions \n Protection of Personal Information \n - We will take reasonable measures to protect personal information from unauthorized access, disclosure, or use. \n - We will store personal information securely and restrict access to authorized personnel. \n - We will not share personal information with third parties without consent, unless required by law. \n Customer Rights \n - Right to access and correct personal information \n - Right to object to processing of personal information \n - Right to lodge a complaint with the Information Regulator \n Contact Details \n - Book Store Name: The Ideal Book Store \n - Contact Person: 044 123 0987 \n - Email: PixelPerfectDev@yahoo.com \n - Phone: [insert phone number] \n Date of Last Update \n – 21/08/2024 \n\n\n 1. POPIA Customer Consent Form:We have a section where a customers is to provide consent for the collection and use of their personal information. It would also explain how their information will be used, shared, and protected. \n 2. POPIA Customer Privacy Notice:We will inform customers about the types of personal information being collected, how it will be used, and their rights regarding their personal information. \n 3. POPIA Customer Data Protection Policy:We will protect customer personal information from unauthorized access, disclosure, or Use.\n  \n\n |and support \n• Marketing and promotional activities \n\n I understand that my personal information will be protected in accordance with the POPIA and The Ideal Book Store’s data protection policies.\n Contact Us \n If you have any questions or concerns about these terms and conditions, please contact us at: \n The Ideal Book Store \n 15, York street \n 044 134 8907 \n PixelPerfectDev@yahoo.com \n Effective Date: These terms and conditions are effective as of 21/08/2024 and supersede all previous versions. ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    MessageBox.Show("Thank you for accepting the privacy policy. Your response has been submitted.");
                    CUSTOMER_DETAILS CUM = new CUSTOMER_DETAILS();
                    CUM.Show();
                    this.Hide();
                    //This code will allow the user to go back to the login after accepting privacy policy and terms and conditions
                }
                else
                {
                    MessageBox.Show("Please read the and accept the privacy policy before accepting.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: "+ ex.Message);
            }
        }

       

      
    }
}
