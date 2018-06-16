using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryCreationTests : AuthTestBase
    {
        [Test]
        public void EntryCreationTest()
        {
            EntryData entryData = new EntryData();
            entryData.Firstname = "Ivan";
            entryData.Middlename = "Ivanovich";
            entryData.Lastname = "Ivanov";
            entryData.Nickname = "akIvan84";
            entryData.Company = "SVC";
            entryData.Address = "Moscow";
            entryData.Home = "1111111111";
            entryData.Mobile = "2222222222";
            entryData.Work = "engineer";
            entryData.Fax = "3333333333";
            entryData.Email = "ivan@email.com";
            entryData.Homepage = "http://homepage/akIvan84";

            applicationManager.Entry.EntryCreater(entryData);
        }
    }
}
