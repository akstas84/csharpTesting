using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            // applicationManager.Navigator.GoToGroupPage();
            applicationManager.Navigator.GoToGroupPage();
            applicationManager.Group.RemovalGroup(1);
            // applicationManager.Navigator.ReturnToGroupPage();

        }
    }
}
