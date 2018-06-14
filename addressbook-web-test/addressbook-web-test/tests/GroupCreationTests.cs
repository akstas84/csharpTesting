using NUnit.Framework;


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

            applicationManager.Group.GroupCreater(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "";
            group.Header = "";
            group.Footer = "";

            applicationManager.Group.GroupCreater(group);
        }
    }
}


