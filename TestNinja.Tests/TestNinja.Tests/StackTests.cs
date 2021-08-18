using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class StackTests
    {
        private Stack _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack();
        }

        [TearDown]
        public void TearDown()
        {
            _stack = null;
        }

        public void Push_ObjIsNull_ThrowArgumentNullException()
        {
            //Arrange
            var stack = _stack;

            //Act - Assert
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ObjIsValid_AddToTheStack()
        {
            //Arrange
            var stack = _stack;

            //Act
            stack.Push("a");

            //Assert
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = _stack;

            //Act - Assert
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_RemoveTopElement()
        {
            //Arrange
            var stack = _stack;

            //Act
            stack.Push("a");
            stack.Pop();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_ReturnTopElement()
        {
            //Arrange
            var stack = _stack;

            //Act
            stack.Push("a");
            stack.Push("b");
            var lastPop = stack.Pop();


            //Assert
            Assert.That(lastPop, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_WhenStackIsEmpty_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = _stack;

            //Act - Assert
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenStackIsNotEmpty_ReturnTopElementValue()
        {
            //Arrange
            var stack = _stack;
            stack.Push("a");
            stack.Push("b");

            //Act
            var result = stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_DoesNotRemoveElements_DontChangeLen()
        {
            //Arrange
            var stack = _stack;
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            stack.Peek();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(3));

        }





    }
}
