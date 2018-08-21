using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
            };

        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModofication(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        private void InitContactModofication(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper(ApplicationManager manager) : base (manager){ }

        public ContactHelper ContactModificator(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(1);
            EditContactButtonClick();
            FillContactForm(contact);
            UpdateButtonClick();
            return this;
        }

        public ContactHelper ContactRemoval()
        {
            manager.Navigator.GoToHomePage();
            SelectContact(1);
            RemoveContact();
            CloseWindowAlert();
            return this;
        }

        private void CloseWindowAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        private void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }

        private void UpdateButtonClick()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        private ContactHelper EditContactButtonClick()
        {
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            }
            else
            {
                Console.WriteLine("КонтактыНеСозданы");
            }
            
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            }
            else
            {
                //Console.WriteLine("КонтактыНеСозданы");
                ContactCreationTests cCreater = new ContactCreationTests();
                cCreater.ContactCreationTest();
            }         
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            if (contact != null )
                Type(By.Name("firstname"), contact.FirstName);
                Type(By.Name("middlename"), contact.Middlename);
                Type(By.Name("lastname"), contact.Lastname);
                Type(By.Name("nickname"), contact.Nickname);
                Type(By.Name("company"), contact.Company);
                Type(By.Name("address"), contact.Address);
                Type(By.Name("home"), contact.HomePhone);
                Type(By.Name("mobile"), contact.MobilePhone);
                Type(By.Name("work"), contact.WorkPhone);
                Type(By.Name("fax"), contact.Fax);
                Type(By.Name("email"), contact.Email);
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
