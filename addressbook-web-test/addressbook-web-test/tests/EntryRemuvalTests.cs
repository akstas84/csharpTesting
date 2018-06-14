using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class EntryRemuvalTests : AuthTestBase
    {
        [Test]
        public void EntryRemuvalTest()
        {
            applicationManager.Entry.RemovalEntry();
        }
    }
}
