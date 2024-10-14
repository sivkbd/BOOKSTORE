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
    public partial class PRIVACY_POLICY : Form
    {
         public string pdffilepath {get;set;}
    
        public PRIVACY_POLICY()
        {
            InitializeComponent();
        }
       

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Navigate(pdffilepath);
            
        }
    }
}
