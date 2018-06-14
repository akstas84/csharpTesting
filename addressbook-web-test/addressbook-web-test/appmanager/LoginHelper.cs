using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public void Login(AccountData accountData)
        {
            if (LoggedIn())
            {
                if (LoggedIn(accountData))
                {
                    return;
                }
                Logout();
            }

            Type(By.Name("user"), accountData.Username);
            Type(By.Name("pass"), accountData.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            if (LoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool LoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool LoggedIn(AccountData accountData)
        {
            return LoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                == "(" + accountData.Username + ")";
        }
    }
}
