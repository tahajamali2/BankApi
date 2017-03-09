using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Drawing.Imaging;
using System.Collections.ObjectModel;


namespace TestBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                HblBank ab = new HblBank("", "");
                var cd = ab.Accounts[0].GetAccountDetails();
            }
            catch
            {

            }
        }
    }
}
