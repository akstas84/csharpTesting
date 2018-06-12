using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenBasePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToEtryPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void PushButtonEnter()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}
