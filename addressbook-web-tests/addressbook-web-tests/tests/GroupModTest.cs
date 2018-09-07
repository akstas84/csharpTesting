using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{

    [TestFixture]
    public class GroupModTest :GroupTestBase
    {

        [Test]
        public void GroupModTests()
        {
            GroupData newData = new GroupData();
            newData.Name = "zzz";
            newData.Footer = null;
            newData.Header = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.GoupModification(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
