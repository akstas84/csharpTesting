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

        public EntryHelper EntryCreater(EntryData entryData)
        {
            manager.Navigator.GoToEtryPage();
            manager.Entry.FillEntryForm(entryData);
            manager.Navigator.PushButtonEnter();
            manager.Navigator.OpenBasePage();
            return this;
        }

        public EntryHelper RemovalEntry()
        {
            manager.Navigator.OpenBasePage();
            SelectEntry();
            PushButtonDeleteEntry();
            PopUpConfirmDeleteEntry();

            return this;
        }

        public EntryHelper Modify(EntryData newEntryData)
        {
            manager.Navigator.OpenBasePage();
            EditEntry();
            FillEntryForm(newEntryData);
            PushButtonUpdate();
            return this;
        }

        public void PopUpConfirmDeleteEntry()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void PushButtonDeleteEntry()
        {
            if (IsElementPresent(By.Name("selected[]")) == true)
            {
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            }
        }

        public void SelectEntry()
        {
            if (IsElementPresent(By.Name("selected[]")) == false)
            {
                EntryData entryData = new EntryData();
                entryData.Firstname = "Sidorov";
                entryData.Home = "!!!!!!!!!!!!";
                entryData.Address = "!!!!!!!!!!!!";
                entryData.Company = "!!!!!!!!!!!!";
                entryData.Email = "!!!!!!!!!!!!";

                manager.Entry.EntryCreater(entryData);
            }
                    driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
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

        public void PushButtonUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
        }

        public void EditEntry()
        {
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")) == false)
            {

            }
                if (IsElementPresent(By.XPath("//img[@alt='Edit']")) == true)
            { 
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            }
        }
    }
}
