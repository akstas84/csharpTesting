using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
            : base (manager)
        {
        }

        public GroupHelper GroupCreater(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModificaton();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        private GroupHelper InitGroupModificaton()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper RemovalGroup(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        private void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        private void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
    }
}
