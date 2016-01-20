using System;

namespace CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetElementAtIndex_FromEmptyList_ShouldThrow()
        {
            var list = new DynamicList<int>();

            var element = list[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementAtIndex_ToEmptyList_ShouldThrow()
        {
            var list = new DynamicList<int>();

            list[0] = 10;
        }

        [TestMethod]
        public void GetElementAtIndex_FromAlreadyInitializedList_ShouldReturnElementAtSpecifiedIndex()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(7);

            var element = list[2];

            Assert.AreEqual(7, element, "The list does not return the correct item.");
        }

        [TestMethod]
        public void SetElementAtIndex_ToAlreadyInitializedList_ShouldSetElementAtSpecifiedIndex()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(7);

            list[0] = 10;

            Assert.AreEqual(10, list[0], "The list does not set the value to the correct item.");
        }

        [TestMethod]
        public void Add_ToEmptyList_ShouldAddItem()
        {
            var list = new DynamicList<string>();

            list.Add("Pesho");

            Assert.AreEqual(1, list.Count, "The count of the list must be increased after adding a new item.");
        }

        [TestMethod]
        public void Add_ToAlreadyInitializedList_ShouldAddItem()
        {
            var list = new DynamicList<string>();

            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Penka");
            list.Add("Ginka");

            Assert.AreEqual(4, list.Count, "The count of the list must be increased after adding a new item.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_FromEmptyList_ShouldThrow()
        {
            var list = new DynamicList<double>();

            list.RemoveAt(12);
        }

        [TestMethod]
        public void RemoveAt_FromAlreadyInitializedList_ShouldDecreaseCountAndReturnTheItem()
        {
            var list = new DynamicList<double>();
            list.Add(5.32);
            list.Add(2.532);
            list.Add(3.21);

            var element = list.RemoveAt(2);

            Assert.AreEqual(3.21, element, "The returned item is not correct.");
            Assert.AreEqual(2, list.Count, "The list should decrement the count of the elements.");
        }

        [TestMethod]
        public void Remove_FromEmptyList_ShouldReturnNegativeOne()
        {
            var list = new DynamicList<double>();

            var index = list.Remove(2.532);

            Assert.AreEqual(-1, index, "The returned index is not correct.");
        }

        [TestMethod]
        public void Remove_FromAlreadyInitializedList_ShouldDecreaseCountAndReturnTheIndexOfTheItem()
        {
            var list = new DynamicList<double>();
            list.Add(5.32);
            list.Add(2.532);
            list.Add(3.21);

            var index = list.Remove(2.532);

            Assert.AreEqual(1, index, "The returned index is not correct.");
            Assert.AreEqual(2, list.Count, "The list should decrement the count of the elements.");
        }

        [TestMethod]
        public void IndexOf_FromEmptyList_ShouldReturnNegativeOne()
        {
            var list = new DynamicList<double>();

            var index = list.IndexOf(2.532);

            Assert.AreEqual(-1, index, "The returned index is not correct.");
        }

        [TestMethod]
        public void IndexOf_FromAlreadyInitializedList_ShouldReturnTheFirstOccurencyIndexOfTheItem()
        {
            var list = new DynamicList<double>();
            list.Add(5.32);
            list.Add(2.532);
            list.Add(3.21);
            list.Add(2.523);

            var index = list.IndexOf(2.532);

            Assert.AreEqual(1, index, "The returned index is not correct.");
        }

        [TestMethod]
        public void Contains_ToEmptyList_ShouldReturnFalse()
        {
            var list = new DynamicList<double>();

            var doesContain = list.Contains(2.532);

            Assert.IsFalse(doesContain, "Must return false when the list is empty.");
        }

        [TestMethod]
        public void Contains_ToAlreadyInitializedList_ShouldReturnTrueOrFalse()
        {
            var list = new DynamicList<long>();
            list.Add(123870814435);
            list.Add(-3275475243432);
            list.Add(9864354472332);
            list.Add(4574552354354756756);
            list.Add(92385023497544325);

            var firstNum = list.Contains(4);
            var secondNum = list.Contains(9864354472332);

            Assert.IsFalse(firstNum);
            Assert.IsTrue(secondNum);
        }
    }
}
