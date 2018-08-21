using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class NavigatorHelper : HelperBase
    {
        private string baseURL;

        public NavigatorHelper(ApplicationManager manager, string baseURL) 
            : base (manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/" 
                && IsElementPresent(By.Name("group")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();

        }
        public void GoToContactPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.Name("submit")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();

        }
    }
}
