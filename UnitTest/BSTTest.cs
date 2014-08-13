using System;
using System.Collections.ObjectModel;
using Algorithm;
using Algorithm.BST;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BSTTest
    {
        [TestMethod]
        public void TestInsert()
        {
            var bst = new CommonBST<int, int>();
            var arr = new[] { 6, 4, 8, 3, 7, 2, 1 };
            var i = 0;
            for (; i < arr.Length; i++)
            {
                bst.Insert(arr[i], arr[i]);
            }
            var arr1 = new int[arr.Length];
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) => arr1[i++] = d);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 6, 7, 8 }, arr1);
            bst.Insert(5, 5);
            i = 0;
            arr1 = new int[arr.Length + 1];
            bst.Traverse(TraverseType.Inorder, (k, d) => arr1[i++] = d);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, arr1);
        }
    }
}
