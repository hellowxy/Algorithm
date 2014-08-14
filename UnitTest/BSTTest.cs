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
            var arr = new[] { 6, 4, 9, 3, 5, 7, 2, 1 };
            var i = 0;
            for (; i < arr.Length; i++)
            {
                bst.Insert(arr[i], arr[i]);
            }
            var arr1 = new int[arr.Length];
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) => arr1[i++] = d);
            foreach (var i1 in arr1)
            {
                Console.WriteLine(i1);
            }
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 9 }, arr1);
            bst.Insert(8, 8);
            i = 0;
            arr1 = new int[arr.Length + 1];
            bst.Traverse(TraverseType.Inorder, (k, d) => arr1[i++] = d);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, arr1);
            bst.Insert(5, -2);
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) => arr1[i++] = d);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, -2, 6, 7, 8, 9 }, arr1);
        }
    }
}
