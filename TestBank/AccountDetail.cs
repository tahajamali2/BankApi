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
using OpenQA.Selenium.Support.UI;
using Supremes.Nodes;

namespace TestBank
{
    public class AccountDetail
    {
        private PhantomJSDriver driver = null;

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

        public AccountStatement GetAccountStatement(DateTime From, DateTime To)
        {
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            driver.SwitchTo().Frame("frame_menu");
            driver.FindElementById("RRAAClink").Click();

            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            driver.SwitchTo().Frame("frame_txn");

            SelectElement elem = new SelectElement(driver.FindElementByName("fldacctno"));
            elem.SelectByValue(this.Account_Value);

            //driver.SwitchTo().Window(driver.CurrentWindowHandle);
            //driver.SwitchTo().Frame("frame_txn");
            var abcd = driver.FindElementsByClassName("objselect");

            SelectElement elem2 = new SelectElement(abcd[1]);
            elem2.SelectByValue("3");

            driver.FindElementById("fldfromdateid").SendKeys(From.ToString("dd-MM-yyyy"));
            driver.FindElementById("fldtodateid").SendKeys(To.ToString("dd-MM-yyyy"));

            driver.FindElementByName("fldsubmit").Click();

            var alltables = driver.FindElementsByClassName("graphtable");
            string abc = alltables[0].GetAttribute("innerHTML");
            Document body = Supremes.Dcsoup.Parse(abc);

            return new AccountStatement();
        }


    }
}
