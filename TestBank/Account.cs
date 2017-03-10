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
    public class Account
    {
        private PhantomJSDriver driver = null;
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
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            driver.SwitchTo().Frame("frame_menu");
            driver.FindElementById("RRADTlink").Click();

            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            driver.SwitchTo().Frame("frame_txn");

            SelectElement elem = new SelectElement(driver.FindElementById("fldacctnodesc"));
            elem.SelectByValue(this.Value);

            driver.FindElementByName("fldsubmit").Click();

            var alltables = driver.FindElementsByClassName("infotable");
            string abc = alltables[0].GetAttribute("innerHTML");
            Document body = Supremes.Dcsoup.Parse(abc);

            AccountDetail detail = new AccountDetail(this.Value,driver);
            detail.AccountTitle = body.Body.TextNodes[1].Text;
            detail.AccountNumber = body.Body.TextNodes[4].Text;

            abc = alltables[2].GetAttribute("innerHTML");
            body = Supremes.Dcsoup.Parse(abc);

            detail.CurrentBalance = Convert.ToDouble(body.Body.TextNodes[2].Text.Replace(",", ""));
            detail.AmountOnHold = Convert.ToDouble(body.Body.TextNodes[4].Text.Replace(",", ""));
            detail.UnClearedFunds = Convert.ToDouble(body.Body.TextNodes[6].Text.Replace(",", ""));
            detail.OverDraftLimit = Convert.ToDouble(body.Body.TextNodes[8].Text.Replace(",", ""));
            detail.AvailableBalance = Convert.ToDouble(body.Body.TextNodes[10].Text.Replace(",", ""));
            detail.NetAvailableBalanceForWithDrawls = Convert.ToDouble(body.Body.TextNodes[12].Text.Replace(",", ""));

            return detail;
        }


    }
}
