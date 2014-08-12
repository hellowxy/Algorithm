using System;
using System.Collections;
using System.Collections.Generic;
using Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CommonUnitTest
    {
        [TestMethod]
        public void Test_ArrayIsNull()
        {
            int[] arr = null;
            IComparer<int> comparer = Comparer<int>.Default;
            try
            {
                Common.Guard(arr,ref comparer);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception,typeof(ArgumentException));
            }
            
        }

        [TestMethod]
        public void Test_ArrayIsEmpty()
        {
            var arr = new int[]{1,2,3};
            IComparer<int> comparer = Comparer<int>.Default;
            try
            {
                Common.Guard(arr, ref comparer);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            }

        }

        [TestMethod]
        public void Test_ComparerIsNull_TIsIComparable()
        {
            var arr = new[] { 1,2,3};
            IComparer<int> comparer = null;
            Common.Guard(arr, ref comparer);
            Assert.IsInstanceOfType(comparer,typeof(Comparer<int>));
            Assert.IsTrue(comparer == Comparer<int>.Default);
        }

        [TestMethod]
        public void Test_ComparerIsNull_TIsNotIComparable()
        {
            var arr = new Object[] { new object(), new object()};
            IComparer<object> comparer = null;
            try
            {
                Common.Guard(arr, ref comparer);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception,typeof(ArgumentException));
            }
            
        }
    }
}
