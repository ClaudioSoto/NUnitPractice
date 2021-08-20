using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    public class HousekeeperHelperTests
    {
        private  string _statementFileName;

        //HOUSEKEEPERHELPER OBJECT FROM CLASS
        private HousekeeperHelper _housekeeperHelper;

        //MOCK OBJECTS
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IStatementGenerator> _mockStatementGenerator;
        private Mock<IEmailSender> _mockEmailSender;
        private Mock<IXtraMessageBox> _mockXtraMesageBox;

        //HOUSE KEEPER OBJECT FOR TEST
        private Housekeeper _housekepper = new Housekeeper();

        //REPEATED DATE FOR FIELDS
        private DateTime _statementDate = new DateTime(2017, 1, 1);

        [SetUp]
        public void SetUp()
        {
          
            //Arrange in every test
            //INITIALIZE HOUSE KEEPWE OBJECT FOR TEST
            _housekepper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };

            //INITIALIZE MOCK OBJECTS
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockStatementGenerator = new Mock<IStatementGenerator>();
            //Arrange
            _statementFileName = "filename";
            _mockStatementGenerator
                .Setup(msg =>
                    msg.SaveStatement(_housekepper.Oid, _housekepper.FullName, _statementDate))
                .Returns(() =>_statementFileName);

            _mockEmailSender = new Mock<IEmailSender>();
            _mockXtraMesageBox = new Mock<IXtraMessageBox>();

            //INITIALIZE THE MEHTOD QUERY AND ITS RETURN
            _mockUnitOfWork.Setup(muof => muof.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekepper
            }.AsQueryable());

            //INITIALIZE HOUSE KEEPER HELPER OBJECT
            _housekeeperHelper = new HousekeeperHelper(
                _mockUnitOfWork.Object,
                _mockStatementGenerator.Object,
                _mockEmailSender.Object,
                _mockXtraMesageBox.Object);
        }

        [TearDown]
        public void TearDown()
        {
            //DESTROY MOCK OBJECTS
            _mockUnitOfWork = null;
            _mockStatementGenerator = null;
            _mockEmailSender = null;
            _mockXtraMesageBox = null;

            //DESTROY HOUSEKEEPER OBJECT FOR TEST
            _housekepper = null;

            //DESTROY HOUSEKEEPERHELPER OBJECT FROM CLASS 
            _housekeeperHelper = null;
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            //Assert
            _mockStatementGenerator.Verify(msg => msg.SaveStatement(_housekepper.Oid, _housekepper.FullName, _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeepersEmailIsNullWhiteSpaceOrEmpty_ShouldNotGenerateStatement(string testCaseValue)
        {
            //Arrange
            _housekepper.Email = testCaseValue;

            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            //Assert
            _mockStatementGenerator.Verify(msg => msg.SaveStatement(_housekepper.Oid, _housekepper.FullName, _statementDate),Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatemet()
        {

            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            //Asseert
            VerifyEmailSended();
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileNameIsNullWhiteSpaceOrEmpty_ShouldNotGenerateEmailTheStatemet(string testCaseValue)
        {
            //Arrange
            _mockStatementGenerator
                .Setup(msg =>
                    msg.SaveStatement(_housekepper.Oid, _housekepper.FullName, _statementDate))
                .Returns(() => testCaseValue);

            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            //Assert
            VerifyEmailIsNotSended();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeepersEmailIsNullWhiteSpaceOrEmpty_ShouldNotGenerateEmailTheStatemet(string testCaseValue)
        {
            //Arrange
            _housekepper.Email = testCaseValue;
            //_statementFileName = testCaseValue;
            _mockStatementGenerator
                .Setup(msg =>
                    msg.SaveStatement(_housekepper.Oid, _housekepper.FullName, _statementDate))
                .Returns(_statementFileName);

            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            //Assert
            VerifyEmailIsNotSended();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            //Arrange
            _mockEmailSender.Setup(mes => mes.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                )).Throws<Exception>();

            //Act
            _housekeeperHelper.SendStatementEmails(_statementDate);

            _mockXtraMesageBox.Verify(mxmb => mxmb.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK), Times.AtLeastOnce);
        }

        //HELPER METHODS
        private void VerifyEmailIsNotSended()
        {
            //Assert
            _mockEmailSender
                .Verify(mes => mes.EmailFile(
                    _housekepper.Email,
                    _housekepper.StatementEmailBody,
                    _statementFileName,
                    It.IsAny<string>()), Times.Never);
        }

        private void VerifyEmailSended()
        {
            //Assert
            _mockEmailSender
                .Verify(mes => mes.EmailFile(
                    _housekepper.Email,
                    _housekepper.StatementEmailBody,
                    _statementFileName,
                    It.IsAny<string>()));
        }

    }

}
