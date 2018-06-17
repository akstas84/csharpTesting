using System;
using System.Collections.Generic;
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

        public GroupHelper RemovalGroup(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitGroupModificaton()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
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

        public void DeleteGroup()
        {
                driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectGroup(int index)
        {
            //if (IsElementPresent(By.Name("selected[]")) == false)
            //{
                //GroupData group = new GroupData();
                //group.Name = "crGroupHelper";
                //group.Header = "crHelperFirst";
                //group.Footer = "crHelperFirst";
                //manager.Group.GroupCreater(group);

                //if (IsElementPresent(By.Name("selected[]")) == true)
                //{
                    driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
                //}
            //}
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
