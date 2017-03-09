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
    public class Account
    {
        PhantomJSDriver driver = null;
        public Account()
        {

        }

        public Account(PhantomJSDriver argdriver)
        {
            driver = argdriver;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public AccountDetail GetAccountDetails()
        {
            return new AccountDetail(Value, driver);
        }


    }
}
