using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
