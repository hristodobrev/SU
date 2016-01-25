namespace DataStructures.Tests
{
    using System;

    using Data_Structures_Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomStackTest
    {
        private CustomStack<int> stack;

        [TestInitialize]
        public void InitializeStack()
        {
            this.stack = new CustomStack<int>();
        }

        [TestMethod]
        public void Push_ToEmptyStack_ShouldIncreaseCount()
        {
            this.stack.Push(20);

            Assert.AreEqual(1, this.stack.Count);
        }

        [TestMethod]
        public void Push_ToFixedCapacityStack_ShouldResizeCorrectly()
        {
            var fixedStack = new CustomStack<string>(2);
            int expectedCount = 100;

            for (int i = 0; i < 100; i++)
            {
                fixedStack.Push(i.ToString());
            }

            Assert.AreEqual(expectedCount, fixedStack.Count);
        }

        [TestMethod]
        public void Peek_FromInitializedStack_ShouldReturnLastElement_WithoutRemovingItFromStack()
        {
            var lastElement = 124;
            this.stack.Push(20);
            this.stack.Push(523);
            this.stack.Push(1257);
            this.stack.Push(9235);
            this.stack.Push(lastElement);

            var expectedElement = this.stack.Peek();

            Assert.AreEqual(expectedElement, lastElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_FromEmptyStack_ShouldThrow()
        {
            this.stack.Peek();
        }
    }
}
