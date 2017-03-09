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
                //var driver = new PhantomJSDriver();
                //driver.Navigate().GoToUrl("https://hblibank.com.pk/");
                //driver.FindElementById("btnProceed").Click();
                //driver.FindElementByName("fldLoginUserId").SendKeys("tahajamali");
                //driver.FindElementByName("fldPassword").SendKeys("taha071999");
                //driver.FindElementById("foo").Click();

                //ReadOnlyCollection<String> handles = driver.WindowHandles;
                //driver.SwitchTo().Window(handles[0]);
                //driver.SwitchTo().Frame("frame_menu");
                //driver.FindElementById("RRAAClink").Click();
                //driver.GetScreenshot().SaveAsFile("tt1.png", ScreenshotImageFormat.Png);

                HblBank ab = new HblBank("tahajamali", "taha071999");
            }
            catch
            {

            }
        }
    }
}
