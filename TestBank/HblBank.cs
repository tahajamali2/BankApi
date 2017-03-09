using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Drawing.Imaging;
using System.Collections.ObjectModel;

namespace TestBank
{
    public class HblBank
    {

        private PhantomJSDriver driver = new PhantomJSDriver();

        public List<Account> Accounts { get; private set; }

        public HblBank(string Username, string Password)
        {
            driver.Navigate().GoToUrl("https://hblibank.com.pk/");
            driver.FindElementById("btnProceed").Click();
            driver.FindElementByName("fldLoginUserId").SendKeys(Username);
            driver.FindElementByName("fldPassword").SendKeys(Password);
            driver.FindElementById("foo").Click();

            ReadOnlyCollection<String> handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[0]);
            driver.SwitchTo().Frame("frame_menu");
            driver.FindElementById("RRAAClink").Click();

            driver.SwitchTo().Frame("frame_txn");
            string abc = driver.FindElementByName("fldacctno").GetAttribute("innerHTML");
        }

        

    }
}
