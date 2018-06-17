using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            List<GroupData> oldGroup = applicationManager.Group.GetGroupList();

            applicationManager.Group.RemovalGroup(0);

            List<GroupData> newGroup = applicationManager.Group.GetGroupList();

            oldGroup.RemoveAt(0);

            Assert.AreEqual(oldGroup, newGroup);

        }
    }
}
