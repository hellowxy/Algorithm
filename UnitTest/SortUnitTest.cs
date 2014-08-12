using System;
using System.Threading.Tasks;
using Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class SortUnitTest
    {
        private T[] GetArrayCopy<T>(T[] arr)
        {
            var copy = new T[arr.Length];
            Parallel.For(0, arr.Length, index => copy[index] = arr[index]);
            return copy;
        }

        private readonly int[] _onlyOneEleArr = new[] { 1 };
        private readonly int[] _onlyTwoEleArr = new[] { 3, 9 };
        private readonly int[] _twoRepeatingEleArr = new[] { 1, 1 };
        private readonly int[] _sameEleArr = new[] { 1, 1, 1 };
        private readonly int[] _orderedArr = new[] { 1, 2, 3, 4, 5 };
        private readonly int[] _reversedArr = new[] { 5, 4, 3, 2, 1 };
        private readonly int[] _arrWithRepeatingEle = new[] { 8, 4, 3, 2, 2, 9, 10, 1, 10 };
        private readonly int[] _arrWithUniqueEle = new[] { 7, 9, 3, 2, 4, 8, 1 };

        private readonly int[] _onlyOneEleArrOrdered = new[] { 1 };
        private readonly int[] _onlyTwoEleArrOrdered = new[] { 3, 9 };
        private readonly int[] _twoRepeatingEleArrOrdered = new[] { 1, 1 };
        private readonly int[] _sameEleArrOrdered = new[] { 1, 1, 1 };
        private readonly int[] _orderedArrOrdered = new[] { 1, 2, 3, 4, 5 };
        private readonly int[] _reversedArrOrdered = new[] { 1, 2, 3, 4, 5 };
        private readonly int[] _arrWithRepeatingEleOrdered = new[] { 1, 2, 2, 3, 4, 8, 9, 10, 10 };
        private readonly int[] _arrWithUniqueEleOrdered = new[] { 1, 2, 3, 4, 7, 8, 9 };

        [TestMethod]
        public void TestBubbleSort()
        {
            var onlyOneEleRet = Sort.BubbleSort(GetArrayCopy(_onlyOneEleArr));
            var onlyTwoEleRet = Sort.BubbleSort(GetArrayCopy(_onlyTwoEleArr));
            var twoRepeatingEleRet = Sort.BubbleSort(GetArrayCopy(_twoRepeatingEleArr));
            var sameEleArrRet = Sort.BubbleSort(GetArrayCopy(_sameEleArr));
            var orderedArrRet = Sort.BubbleSort(GetArrayCopy(_orderedArr));
            var reversedArrRet = Sort.BubbleSort(GetArrayCopy(_reversedArr));
            var arrWithRepeatingEleRet = Sort.BubbleSort(GetArrayCopy(_arrWithRepeatingEle));
            var arrWithUniqueEleRet = Sort.BubbleSort(GetArrayCopy(_arrWithUniqueEle));

            CollectionAssert.AreEqual(_onlyOneEleArrOrdered,onlyOneEleRet);
            CollectionAssert.AreEqual(_onlyTwoEleArrOrdered, onlyTwoEleRet);
            CollectionAssert.AreEqual(_twoRepeatingEleArrOrdered, twoRepeatingEleRet);
            CollectionAssert.AreEqual(_sameEleArrOrdered, sameEleArrRet);
            CollectionAssert.AreEqual(_orderedArrOrdered, orderedArrRet);
            CollectionAssert.AreEqual(_reversedArrOrdered, reversedArrRet);
            CollectionAssert.AreEqual(_arrWithRepeatingEleOrdered, arrWithRepeatingEleRet);
            CollectionAssert.AreEqual(_arrWithUniqueEleOrdered, arrWithUniqueEleRet);
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            var onlyOneEleRet = Sort.InsertionSort(GetArrayCopy(_onlyOneEleArr));
            var onlyTwoEleRet = Sort.InsertionSort(GetArrayCopy(_onlyTwoEleArr));
            var twoRepeatingEleRet = Sort.InsertionSort(GetArrayCopy(_twoRepeatingEleArr));
            var sameEleArrRet = Sort.InsertionSort(GetArrayCopy(_sameEleArr));
            var orderedArrRet = Sort.InsertionSort(GetArrayCopy(_orderedArr));
            var reversedArrRet = Sort.InsertionSort(GetArrayCopy(_reversedArr));
            var arrWithRepeatingEleRet = Sort.InsertionSort(GetArrayCopy(_arrWithRepeatingEle));
            var arrWithUniqueEleRet = Sort.InsertionSort(GetArrayCopy(_arrWithUniqueEle));

            CollectionAssert.AreEqual(_onlyOneEleArrOrdered, onlyOneEleRet);
            CollectionAssert.AreEqual(_onlyTwoEleArrOrdered, onlyTwoEleRet);
            CollectionAssert.AreEqual(_twoRepeatingEleArrOrdered, twoRepeatingEleRet);
            CollectionAssert.AreEqual(_sameEleArrOrdered, sameEleArrRet);
            CollectionAssert.AreEqual(_orderedArrOrdered, orderedArrRet);
            CollectionAssert.AreEqual(_reversedArrOrdered, reversedArrRet);
            CollectionAssert.AreEqual(_arrWithRepeatingEleOrdered, arrWithRepeatingEleRet);
            CollectionAssert.AreEqual(_arrWithUniqueEleOrdered, arrWithUniqueEleRet);
        }

        [TestMethod]
        public void TestMergeSort()
        {
            var onlyOneEleRet = Sort.MergeSort(GetArrayCopy(_onlyOneEleArr));
            var onlyTwoEleRet = Sort.MergeSort(GetArrayCopy(_onlyTwoEleArr));
            var twoRepeatingEleRet = Sort.MergeSort(GetArrayCopy(_twoRepeatingEleArr));
            var sameEleArrRet = Sort.MergeSort(GetArrayCopy(_sameEleArr));
            var orderedArrRet = Sort.MergeSort(GetArrayCopy(_orderedArr));
            var reversedArrRet = Sort.MergeSort(GetArrayCopy(_reversedArr));
            var arrWithRepeatingEleRet = Sort.MergeSort(GetArrayCopy(_arrWithRepeatingEle));
            var arrWithUniqueEleRet = Sort.MergeSort(GetArrayCopy(_arrWithUniqueEle));

            CollectionAssert.AreEqual(_onlyOneEleArrOrdered, onlyOneEleRet);
            CollectionAssert.AreEqual(_onlyTwoEleArrOrdered, onlyTwoEleRet);
            CollectionAssert.AreEqual(_twoRepeatingEleArrOrdered, twoRepeatingEleRet);
            CollectionAssert.AreEqual(_sameEleArrOrdered, sameEleArrRet);
            CollectionAssert.AreEqual(_orderedArrOrdered, orderedArrRet);
            CollectionAssert.AreEqual(_reversedArrOrdered, reversedArrRet);
            CollectionAssert.AreEqual(_arrWithRepeatingEleOrdered, arrWithRepeatingEleRet);
            CollectionAssert.AreEqual(_arrWithUniqueEleOrdered, arrWithUniqueEleRet);
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var onlyOneEleRet = Sort.QuickSort_Native(GetArrayCopy(_onlyOneEleArr));
            var onlyTwoEleRet = Sort.QuickSort_Native(GetArrayCopy(_onlyTwoEleArr));
            var twoRepeatingEleRet = Sort.QuickSort_Native(GetArrayCopy(_twoRepeatingEleArr));
            var sameEleArrRet = Sort.QuickSort_Native(GetArrayCopy(_sameEleArr));
            var orderedArrRet = Sort.QuickSort_Native(GetArrayCopy(_orderedArr));
            var reversedArrRet = Sort.QuickSort_Native(GetArrayCopy(_reversedArr));
            var arrWithRepeatingEleRet = Sort.QuickSort_Native(GetArrayCopy(_arrWithRepeatingEle));
            var arrWithUniqueEleRet = Sort.QuickSort_Native(GetArrayCopy(_arrWithUniqueEle));

            CollectionAssert.AreEqual(_onlyOneEleArrOrdered, onlyOneEleRet);
            CollectionAssert.AreEqual(_onlyTwoEleArrOrdered, onlyTwoEleRet);
            CollectionAssert.AreEqual(_twoRepeatingEleArrOrdered, twoRepeatingEleRet);
            CollectionAssert.AreEqual(_sameEleArrOrdered, sameEleArrRet);
            CollectionAssert.AreEqual(_orderedArrOrdered, orderedArrRet);
            CollectionAssert.AreEqual(_reversedArrOrdered, reversedArrRet);
            CollectionAssert.AreEqual(_arrWithRepeatingEleOrdered, arrWithRepeatingEleRet);
            CollectionAssert.AreEqual(_arrWithUniqueEleOrdered, arrWithUniqueEleRet);
        }

        [TestMethod]
        public void TestHeapSort()
        {
            var onlyOneEleRet = Sort.HeapSort(GetArrayCopy(_onlyOneEleArr));
            var onlyTwoEleRet = Sort.HeapSort(GetArrayCopy(_onlyTwoEleArr));
            var twoRepeatingEleRet = Sort.HeapSort(GetArrayCopy(_twoRepeatingEleArr));
            var sameEleArrRet = Sort.HeapSort(GetArrayCopy(_sameEleArr));
            var orderedArrRet = Sort.HeapSort(GetArrayCopy(_orderedArr));
            var reversedArrRet = Sort.HeapSort(GetArrayCopy(_reversedArr));
            var arrWithRepeatingEleRet = Sort.HeapSort(GetArrayCopy(_arrWithRepeatingEle));
            var arrWithUniqueEleRet = Sort.HeapSort(GetArrayCopy(_arrWithUniqueEle));

            CollectionAssert.AreEqual(_onlyOneEleArrOrdered, onlyOneEleRet);
            CollectionAssert.AreEqual(_onlyTwoEleArrOrdered, onlyTwoEleRet);
            CollectionAssert.AreEqual(_twoRepeatingEleArrOrdered, twoRepeatingEleRet);
            CollectionAssert.AreEqual(_sameEleArrOrdered, sameEleArrRet);
            CollectionAssert.AreEqual(_orderedArrOrdered, orderedArrRet);
            CollectionAssert.AreEqual(_reversedArrOrdered, reversedArrRet);
            CollectionAssert.AreEqual(_arrWithRepeatingEleOrdered, arrWithRepeatingEleRet);
            CollectionAssert.AreEqual(_arrWithUniqueEleOrdered, arrWithUniqueEleRet);
        }
    }
}
