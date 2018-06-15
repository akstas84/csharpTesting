using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private string baseURL;

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

        public GroupHelper RemovalGroup(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            DeleteGroup();
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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        private void DeleteGroup()
        {
                driver.FindElement(By.Name("delete")).Click();
        }

        private void SelectGroup(int index)
        {
            if (IsElementPresent(By.Name("selected[]")) == false)
            {
                GroupData group = new GroupData();
                group.Name = "crGroupHelper";
                group.Header = "crHelperFirst";
                group.Footer = "crHelperFirst";
                manager.Group.GroupCreater(group);

                if (IsElementPresent(By.Name("selected[]")) == true)
                {
                    driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
                }
            }
        }
    }
}
