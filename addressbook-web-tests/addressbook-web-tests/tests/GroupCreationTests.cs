﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{

    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        //public static IEnumerable<GroupData> RandomGroupDataProvider()
        //{
        //    List<GroupData> goups = new List<GroupData>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        goups.Add(new GroupData(GenerateRandomString(30))
        //        {
        //            Header = GenerateRandomString(100),
        //            Footer = GenerateRandomString(100)
        //        });
        //    }
        //}

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                   .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = new GroupData();
            //group.Name = "AAA";
            //group.Footer = "BBB";
            //group.Header = "CCC";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData();
            group.Name = "a'a";
            group.Footer = "";
            group.Header = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
