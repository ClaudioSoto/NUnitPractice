using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatterClassObject;

        [SetUp]
        public void SetUp()
        {
            _htmlFormatterClassObject = new HtmlFormatter();
        }

        [TearDown]
        public void TearDown()
        {
            _htmlFormatterClassObject = null;
        }

        [Test]
        [TestCase("a")]
        [TestCase("A")]
        [TestCase("aA")]
        [TestCase("Aa")]
        public void FormatAsBold_UseStrongLabels_ReturnBoldHtmlString(string word)
        {
            //Act
            var result = _htmlFormatterClassObject.FormatAsBold(word);

            //Arrange
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.Contain(word).IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
        }

    }
}
