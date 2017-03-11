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
using System.Globalization;

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
            if (driver != null)
            {

                try { 

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

                AccountStatement statement = new AccountStatement();
                statement.OpeningBalance = HelpingClass.ToDouble(body.Body.TextNodes[4].Text);
                statement.ClosingBalance = HelpingClass.ToDouble(body.Body.TextNodes[5].Text);

                abc = alltables[1].GetAttribute("innerHTML");
                body = Supremes.Dcsoup.ParseBodyFragment("<table>" + abc + "</table>");

                List<AccountActivity> activities = new List<AccountActivity>();
                AccountActivity activity = new AccountActivity();

                Elements trs = body.Select("tr");
                Elements tds = null;

                bool isavilable = false;

                abc = driver.FindElementByClassName("standardtable").GetAttribute("innerHTML");
                body = Supremes.Dcsoup.ParseBodyFragment("<table>" + abc + "</table>");
                string[] arr = body.Body.Text.Split(new string[] { "Pages : (" }, StringSplitOptions.None);
                int totalpage = Convert.ToInt32(arr[1].Split(')')[0].Trim());
                int currentpage = 1;
                do
                {
                    for (int i = 0; i < trs.Count; i++)
                    {
                        if (i != 0)
                        {
                            tds = trs[i].Select("td");
                            activity = new AccountActivity();

                            activity.TransactionDate = DateTime.ParseExact(tds[0].OwnText, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            activity.ValueDate = DateTime.ParseExact(tds[1].OwnText, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            activity.TransactionReferenceNo = tds[2].OwnText;
                            activity.Description = tds[3].OwnText;
                            activity.Debit = HelpingClass.ToDouble(tds[4].OwnText);
                            activity.Credit = HelpingClass.ToDouble(tds[5].OwnText);
                            activity.Balance = HelpingClass.ToDouble(tds[6].OwnText);

                            activities.Add(activity);
                        }
                    }

                    if (currentpage < totalpage)
                    {
                        currentpage++;
                        driver.FindElementByCssSelector("a[href=\"javascript:SendPageRequest(" + currentpage.ToString() + ")\"]").Click();

                        alltables = driver.FindElementsByClassName("graphtable");
                        abc = alltables[1].GetAttribute("innerHTML");
                        body = Supremes.Dcsoup.ParseBodyFragment("<table>" + abc + "</table>");

                        trs = body.Select("tr");
                        isavilable = true;
                    }
                    else
                    {
                        isavilable = false;
                    }

                } while (isavilable);

                statement.Activities = activities.AsReadOnly();

                return statement;

            
                }

                catch
                {
                    throw new Exception("(ErrorCode:11) Network Or Service is not available Or May be Problem occured While Fetching Account Details Try Again..");
                }

            }

            else
            {
                throw new Exception("(ErrorCode:10) Account Detail object not initialized");
            }
        }

    }
}
