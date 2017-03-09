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
    public class AccountDetail
    {
        PhantomJSDriver driver = null;

        public AccountDetail(string AccountValue, PhantomJSDriver argdriver)
        {
            Account_Value = AccountValue;
            driver = argdriver;
        }

        private string Account_Value { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public double CurrentBalance { get; set; }
        public double AmountOnHold { get; set; }
        public double OverDraftLimit { get; set; }
        public double UnClearedFunds { get; set; }
        public double AvailableBalance { get; set; }
        public double NetAvailableBalanceForWithDrawls { get; set; }


    }
}
