﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            applicationManager.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);
            Assert.IsTrue(applicationManager.Auth.LoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            applicationManager.Auth.Logout();
            AccountData account = new AccountData("admin", "123456");
            applicationManager.Auth.Login(account);
            Assert.IsFalse(applicationManager.Auth.LoggedIn(account));
        }
    }
}
