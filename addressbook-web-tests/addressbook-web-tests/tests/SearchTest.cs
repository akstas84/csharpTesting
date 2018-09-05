using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    class SearchTest : AuthTestBase
    {
        [Test]
        public void Testsearch()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }
    }
}
