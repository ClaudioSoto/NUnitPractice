using NUnit.Framework;
using System.Collections;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [TearDown]
        public void TearDown()
        {
            _stack = null;
        }

        [Test]
        public void Push_InsertNullObj_ReturnArgumentNullException()
        {
            //Arrange - Act - Assert
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_NotNullObject_StoreIntoStack()
        {
            //Arrange - Act
            _stack.Push("a");

            //Asseet
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ReturnInvalidOperationException()
        {
            //Arrange - Act - Assert
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_ReturnNewStack()
        {
            //Arrange - Act
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            var result = _stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenStackIsEmpty_ReturnInvalidOperationException()
        {
            //Arrange - Act - Assert
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenStackIsNotEmpty_ReturPeekElement()
        {
            //Arrange - Act
            _stack.Push("a");
            _stack.Push("b");
            var result = _stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("b"));
            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
