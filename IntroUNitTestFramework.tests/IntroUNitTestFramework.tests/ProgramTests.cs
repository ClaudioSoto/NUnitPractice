﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroUNitTestFramework.tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Program _program;

        /*
         * THIS TEST SUITE HAVE SEVERAL TEST CASES FOR IntroUNiTestFramework project
         */

        //METHOD FOR INITIALIZE THE OBJECT PROGRAM EVERY TIME A TEST IS FINISHED
        [SetUp]
        public void SetUp()
        {
            _program = new Program();
        }
        
        /*
         * TESTCASES FOR LOGIN 
         */

        [Test]
        [TestCase("","")]
        [TestCase("", "password")]
        [TestCase("user", "")]
        public void Login_UserOrPassEmpty_ReturnError(string user, string password)
        {

            //Arrange - Act
            var result = _program.Login(user,password);
    
            //Assert
            Assert.That(result, Is.EqualTo("Userid or password could not be Empty."));
        }

        [Test]
        public void Login_UserOrPassAdmin_ReturnWelcomeAdmin()
        {
            //Arrange - Act
            var result = _program.Login("Admin", "Admin");

            //Assert
            Assert.That(result, Is.EqualTo("Welcome Admin."));

        }

        [Test]
        public void Login_UserAndPasswordNotEmptyNotAdmin_ReturnError()
        {
            //Arrange - Act
            var result = _program.Login("user", "user");

            //Assert
            Assert.That(result, Is.EqualTo("Incorrect UserId or Password."));
        }

        /*
         * TESTCASES FOR GETDETAILS
         */

        [Test]
        public void GetDetails_UserExists_ReturnUserInfo()
        {
            //Arrange - Act
            var result = _program.getDetails(100);

            //Assert
            foreach(var user in result)
            {
                Assert.That(user.id, Is.EqualTo(100));
                Assert.That(user.Name, Is.EqualTo("Bharat"));
                Assert.That(user.Geneder, Is.EqualTo("male"));
                Assert.That(user.salary, Is.EqualTo(40000));
            }

        }

        [Test]
        public void GetDetails_NotUserCloned_ReturnSameLen()
        {
            //Arrange - Act
            var result = _program.AllUsers();
            HashSet<int> s = new HashSet<int>();

            foreach(var idUser in result)
            {
                s.Add(idUser.id);
            }

            //Assert
            Assert.That(result.Count, Is.EqualTo(s.Count));

        }

        /*
         * TESTCASES FOR ALLUSERS
         */
        [Test]
        public void AllUsers_CheckIfAttributesAreNotEmptyOrNull_ReturnList()
        {
            //Arrange - Act
            var result = _program.AllUsers();

            //Assert
            foreach(var user in result)
            {
                Assert.That(user.id, Is.Not.Null);
                Assert.That(user.Name, Is.Not.Null);
                Assert.That(user.salary, Is.Not.Null);
                Assert.That(user.Geneder, Is.Not.Null);
            }
        }

        [Test]
        public void AllUsers_NumberOfUsers_ReturnSeven()
        {
            //Arrange - Act
            var result = _program.AllUsers().Count;

            //Assert
            Assert.That(result, Is.EqualTo(7));

        }
    }
}
