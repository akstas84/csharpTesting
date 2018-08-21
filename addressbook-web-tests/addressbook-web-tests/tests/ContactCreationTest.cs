using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToContactPage();
            ContactData contact = new ContactData();
            contact.FirstName = "Ivan";
            contact.Middlename = "Ivanovich";
            contact.Lastname = "ivanov";
            contact.Nickname = "iv";
            contact.Company = "svc";
            contact.Address = "Moscow";
            contact.HomePhone = "11111111";
            contact.MobilePhone = "2222222";
            contact.WorkPhone = "3333333";
            contact.Fax = "0000000";
            contact.Email = "ok@ok.ok";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactForm();
        }
    }
}
