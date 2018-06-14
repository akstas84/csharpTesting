using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class EntryHelper : HelperBase
    {
        public EntryHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public EntryHelper RemovalEntry()
        {
            manager.Navigator.OpenBasePage();
            SelectEntry();
            PushButtonDeleteEntry();
            PopUpConfirmDeleteEntry();
            return this;
        }

        private void PopUpConfirmDeleteEntry()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private void PushButtonDeleteEntry()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }

        private void SelectEntry()
        {
            driver.FindElement(By.XPath("//*[starts-with(@name,'selected')]")).Click();
        }

        public void FillEntryForm(EntryData entryData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entryData.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(entryData.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entryData.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(entryData.Nickname);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(entryData.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(entryData.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(entryData.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(entryData.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(entryData.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(entryData.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(entryData.Email);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(entryData.Homepage);
        }

        public EntryHelper Modify(EntryData newEntryData)
        {
            manager.Navigator.OpenBasePage();
            EditEntry();
            FillEntryForm(newEntryData);
            PushButtonUpdate();
            return this;
        }

        private void PushButtonUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
        }

        private void EditEntry()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }
    }
}
