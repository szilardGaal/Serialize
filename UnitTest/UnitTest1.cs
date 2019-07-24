using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreateClass;
using System.Text.RegularExpressions;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Employee TestPerson1 = new Employee("Sanyi", DateTime.Parse("1994-03-21"), "MALE", 1234, "zabhegyezõ", new Room(4));
        Person TestPerson2 = new Person("Klára", DateTime.Parse("1998-05-08"), "FEMALE");

        [TestMethod]
        public void TestInstanceCreation()
        {
            Assert.IsTrue(TestPerson1.Name == "Sanyi");
            Assert.IsTrue(TestPerson1.Gender == Gender.MALE);
            Assert.IsTrue(TestPerson1.Salary == 1234);
            Assert.IsTrue(TestPerson1.Profession == "zabhegyezõ");

            Assert.IsTrue(TestPerson2.Name == "Klára");
            Assert.IsTrue(TestPerson2.Gender == Gender.FEMALE);
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            Assert.IsTrue(Regex.IsMatch(TestPerson1.ToString(), @"NAME:Sanyi\nAGE: \d{1,2}\nBIRTH:21/03/1994 00:00:00\nGENDER: MALE\nPROFESSION:zabhegyezõ\nSALARY: 1234\nCurrently in Room #4"));
            Assert.IsTrue(Regex.IsMatch(TestPerson2.ToString(), @"NAME:Klára\nAGE: \d{1,2}\nBIRTH:08/05/1998 00:00:00\nGENDER: FEMALE"));
        }

        [TestMethod]
        public void TestSerialization()
        {
            TestPerson1.Serialize(@"C:\testSer.bin");
            TestPerson2.Serialize(@"C:\testSer2.bin");

            Assert.IsTrue(File.Exists(@"C:\testSer.bin"));
            Assert.IsTrue(File.Exists(@"C:\testSer2.bin"));

            File.Delete(@"C:\testSer.bin");
            File.Delete(@"C:\testSer2.bin");
        }

        [TestMethod]
        public void TestDeserialization()
        {
            TestPerson1.Serialize(@"C:\testSer.bin");
            Person ReloadedPerson = Person.Deserialize(@"C:\testSer.bin");

            Assert.IsTrue(TestPerson1.Name == ReloadedPerson.Name);
            Assert.IsTrue(TestPerson1.Gender == ReloadedPerson.Gender);
            Assert.IsTrue(TestPerson1.Age == ReloadedPerson.Age);
            Assert.IsTrue(TestPerson1.Profession == ((Employee)ReloadedPerson).Profession);

            File.Delete(@"C:\testSer.bin");
        }
    }
}
