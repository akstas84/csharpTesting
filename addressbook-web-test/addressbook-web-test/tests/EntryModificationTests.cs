using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class EntryModificationTests : AuthTestBase
    {
        [Test]
        public void EntryModificationTest()
        {
            EntryData newEntryData = new EntryData();
            newEntryData.Firstname = "newIvan";
            newEntryData.Middlename = "newIvanovich";
            newEntryData.Lastname = "newIvanov";
            newEntryData.Nickname = "newakIvan84";
            newEntryData.Company = "newSVC";
            newEntryData.Address = "newMoscow";
            newEntryData.Home = "new1111111111";
            newEntryData.Mobile = "new2222222222";
            newEntryData.Work = "newengineer";
            newEntryData.Fax = "new3333333333";
            newEntryData.Email = "newivan@email.com";
            newEntryData.Homepage = "newhttp://homepage/akIvan84";
            applicationManager.Entry.Modify(newEntryData);
        }
    }
}
