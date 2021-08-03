using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DemoProject;
namespace DemoProjectTest
{
    [TestFixture]
    public class DemoTests
    {
        List<EmployeeDetails> li;
        [Test]
        public void Checkdetails()
        {
            Program pobj = new Program();
            li = pobj.AllUsers();
            foreach (var x in li)
            {
                Assert.IsNotNull(x.id);
                Assert.IsNotNull(x.Name);
                Assert.IsNotNull(x.salary);
                Assert.IsNotNull(x.Geneder);
            }
        }
        [Test]
        public void TestLogin()
        {
            Program pobj = new Program();
            string x = pobj.Login("Ajit", "1234");
            string y = pobj.Login("", "");
            string z = pobj.Login("Admin", "Admin");
            string a = pobj.Login("claudio", "");
            Assert.AreEqual("Userid or password could not be Empty.", y);
            Assert.AreEqual("Incorrect UserId or Password.", x);
            Assert.AreEqual("Welcome Admin.", z);
            Assert.AreEqual("Userid or password could not be Empty.", a);
        }
        [Test]
        public void getuserdetails()
        {
            Program pobj = new Program();
            var p = pobj.getDetails(100);
            foreach (var x in p)
            {
                Assert.AreEqual(x.id, 100);
                Assert.AreEqual(x.Name, "Bharat");
            }
        }
        [Test]
        public void CheckIfClaudioExists()
        {
            Program pobj = new Program();
            var p = pobj.getDetails(107);
            foreach (var x in p)
            {
                Assert.AreEqual(x.id, 107);
                Assert.AreEqual(x.Name, "Claudio");
            }
        }

        //TEST CASES PARA VER COMO FUNCIONA SETUP Y TEAR DOWN
        [Test]
        [SetUp]
        public void AddTestCase()
        {
            int x = 10;
            int y = 10;
            int z = x + y;
            Assert.AreEqual(z, 20);
        }
        [Test]
        public void SubstractTestCase()
        {
            int x = 10;
            int y = 11;
            int z = y - x;
            Assert.AreEqual(1, z);
        }

        [Test]
        [TearDown]
        public void MultiplyTestCase()
        {
            int x = 5;
            int y = 5;
            int z = y * x;
            Assert.AreEqual(25, z);
        }
    }
}