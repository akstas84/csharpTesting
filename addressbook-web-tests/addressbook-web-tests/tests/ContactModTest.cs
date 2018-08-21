
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class ContactModTest : AuthTestBase
    {

        [Test]
        public void ContactModTests()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "PARAPAPAMPAMPIUWW";
            app.Contacts.ContactModificator(contact);
        }
    }
}
