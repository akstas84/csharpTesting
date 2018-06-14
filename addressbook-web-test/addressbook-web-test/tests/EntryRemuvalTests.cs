using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class EntryRemuvalTests : TestBase
    {
        [Test]
        public void EntryRemuvalTest()
        {
            applicationManager.Entry.RemovalEntry();
        }
    }
}
