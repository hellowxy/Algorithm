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
            try
            {
                Common.GuardArrayNotEmpty(arr);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception,typeof(ArgumentException));
            }
            
        }

        [TestMethod]
        public void Test_ArrayIsEmpty()
        {
            var arr = new int[0];
            try
            {
                Common.GuardArrayNotEmpty(arr);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception, typeof(ArgumentException));
            }

        }

        [TestMethod]
        public void Test_ComparerIsNull_TIsIComparable()
        {
            IComparer<int> comparer = null;
            Common.GuardComparer(ref comparer);
            Assert.IsInstanceOfType(comparer,typeof(Comparer<int>));
            Assert.IsTrue(object.ReferenceEquals(comparer,Comparer<int>.Default));
        }

        [TestMethod]
        public void Test_ComparerIsNull_TIsNotIComparable()
        {
            IComparer<object> comparer = null;
            try
            {
                Common.GuardComparer(ref comparer);
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception,typeof(ArgumentException));
            }
            
        }
    }
}
