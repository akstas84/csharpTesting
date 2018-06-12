using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager applicationManager;

        [SetUp]
        public void SetupTest()
        {
            //FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            //options.UseLegacyImplementation = true;
            //driver = new FirefoxDriver(options);
            //baseURL = "http://localhost/";
            //verificationErrors = new StringBuilder();

            applicationManager = new ApplicationManager();
            applicationManager.Navigator.OpenBasePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));

        }

        [TearDown]
        public void TeardownTest()
        {
            applicationManager.Stop();
        }
    }
}
