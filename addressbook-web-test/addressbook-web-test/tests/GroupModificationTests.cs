﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData();
            newData.Name = "newName";
            newData.Header = null;
            newData.Footer = null;
            applicationManager.Group.Modify(0, newData);
        }
    }
}
