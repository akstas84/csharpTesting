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
            Type(By.Name("firstname"), entryData.Firstname);
            Type(By.Name("lastname"), entryData.Lastname);
            Type(By.Name("nickname"), entryData.Nickname);
            Type(By.Name("company"), entryData.Company);
            Type(By.Name("address"), entryData.Address);
            Type(By.Name("home"), entryData.Home);
            Type(By.Name("middlename"), entryData.Middlename);
            Type(By.Name("mobile"), entryData.Mobile);
            Type(By.Name("work"), entryData.Work);
            Type(By.Name("fax"), entryData.Fax);
            Type(By.Name("email"), entryData.Email);
            Type(By.Name("homepage"), entryData.Homepage);
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
