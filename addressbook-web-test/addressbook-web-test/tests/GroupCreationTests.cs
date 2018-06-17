using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "FirstGroup";
            group.Header = "First";
            group.Footer = "First";

            List<GroupData> oldGroup = applicationManager.Group.GetGroupList(); 

            applicationManager.Group.GroupCreater(group);

            List<GroupData> newGroup = applicationManager.Group.GetGroupList();
            Assert.AreEqual(oldGroup.Count + 1, newGroup.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "";
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroup = applicationManager.Group.GetGroupList();

            applicationManager.Group.GroupCreater(group);

            List<GroupData> newGroup = applicationManager.Group.GetGroupList();
            Assert.AreEqual(oldGroup.Count + 1, newGroup.Count);
        }

        [Test]
        public void BadBugGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "a'a";
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroup = applicationManager.Group.GetGroupList();

            applicationManager.Group.GroupCreater(group);

            List<GroupData> newGroup = applicationManager.Group.GetGroupList();
            Assert.AreEqual(oldGroup.Count + 1, newGroup.Count);
        }
    }
}


