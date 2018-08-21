using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTest : AuthTestBase
    {
        [Test]
        public void ContactRemovalTests()
        {            
            app.Contacts.ContactRemoval();
        }
    }
}
