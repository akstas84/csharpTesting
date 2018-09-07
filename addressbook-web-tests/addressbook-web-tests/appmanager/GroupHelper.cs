using System;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base (manager) { }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGrroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                }
        }
            return new List<GroupData>(groupCache);

            //List<GroupData> groups = new List<GroupData>();
            //manager.Navigator.GoToGroupsPage();
            //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            //foreach (IWebElement element in elements)
            //{
            //    groups.Add(new GroupData(element.Text));
            //}
            //return groups;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper GoupModification(int v, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            EditGroupButtonClick();
            FillGroupForm(group);
            UpdateButtonClick();
            ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper UpdateButtonClick()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper EditGroupButtonClick()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {     
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        public GroupHelper InitGrroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            }
            //else
            //{
            //    //Console.WriteLine("ГруппыНеСозданы");
            //    GroupCreationTests gCreater = new GroupCreationTests();
            //    gCreater.GroupCreationTest();
            //}               
            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+ id+"'])")).Click();             
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
    }
}
