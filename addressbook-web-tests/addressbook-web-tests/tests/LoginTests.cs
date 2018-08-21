using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWhithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.isLoggedIn(account));
        }

        [Test]
        public void LoginWhithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.isLoggedIn(account));
        }
    }
}
