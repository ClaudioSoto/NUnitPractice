using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTestsEjercicio3
    {
        //PUSH
        [Test]
        public void Push_IfObjectEqualToNull_ReturnArgumentNullException()
        {
            var stackObj = new Fundamentals.Stack<string>();
            Assert.That(() => stackObj.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidArg_AddObjectToTheStack()
        {
            var stackObj = new Fundamentals.Stack<string>();

            stackObj.Push("a");

            Assert.That(stackObj.Count,Is.EqualTo(1));
        }

        //POP
        [Test]
        public void Pop_EmptyStack_InvalidOperationException()
        {
            var stackObj = new Fundamentals.Stack<string>();
            Assert.That(() => stackObj.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_NotEmptyStack_DeleteObjectFromStack()
        {
            var stackObj = new Fundamentals.Stack<string>();
            stackObj.Push("a");
            var result = stackObj.Pop();
            Assert.That(result, Is.EqualTo("a"));
        }

        //PEAK
        [Test]
        public void Peek_EmptyStack_InvalidOperationException()
        {
            var stackObj = new Fundamentals.Stack<string>();
            Assert.That(() => stackObj.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_NotEmptyStack_ReturnFirstElementInStack()
        {
            var stackObj = new Fundamentals.Stack<string>();
            stackObj.Push("a");
            stackObj.Push("b");
            var result = stackObj.Peek();
            Assert.That(result, Is.EqualTo("b"));
        }

    }
}
