using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            var i = 0;
            int data;
            var get = bst.TryGetData(4, out data);
            Assert.IsFalse(get);

            bst.InsertOrUpdate(1, 1);
            get = bst.TryGetData(1, out data);
            Assert.IsTrue(get);
            Assert.IsTrue(data == 1);

            bst.InsertOrUpdate(1, 10);
            get = bst.TryGetData(1, out data);
            Assert.IsTrue(get);
            Assert.IsTrue(data == 10);

            bst.Clear();

            for (; i < 8; i++)
            {
                bst.InsertOrUpdate(i * 2, i);
            }
            var arrData = new int[8];
            var arrKey = new int[8];
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) =>
            {
                arrData[i] = d;
                arrKey[i] = k;
                i++;
            });
            Console.WriteLine();
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, arrData);
            CollectionAssert.AreEqual(new int[] { 0, 2, 4, 6, 8, 10, 12, 14 }, arrKey);
            bst.InsertOrUpdate(5, 10);
            i = 0;
            arrKey = new int[9];
            arrData = new int[9];
            bst.Traverse(TraverseType.Inorder, (k, d) =>
            {
                arrData[i] = d;
                arrKey[i] = k;
                i++;
            });
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 10, 3, 4, 5, 6, 7 }, arrData);
            CollectionAssert.AreEqual(new int[] { 0, 2, 4, 5, 6, 8, 10, 12, 14 }, arrKey);
            bst.InsertOrUpdate(5, -2);
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) =>
            {
                arrData[i] = d;
                arrKey[i] = k;
                i++;
            });
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, -2, 3, 4, 5, 6, 7 }, arrData);
            CollectionAssert.AreEqual(new int[] { 0, 2, 4, 5, 6, 8, 10, 12, 14 }, arrKey);
        }

        [TestMethod]
        public void TestRemove()
        {
            var bst = new CommonBST<int, int>();
            bst.InsertOrUpdate(1, 1);
            var remove = bst.Remove(1);
            Assert.IsTrue(remove);
            Assert.IsTrue(bst.IsEmpty());
            var i = 1;
            bst.InsertOrUpdate(4, 4);
            bst.InsertOrUpdate(2, 2);
            bst.InsertOrUpdate(6, 6);
            bst.InsertOrUpdate(1, 1);
            bst.InsertOrUpdate(3, 3);
            bst.InsertOrUpdate(5, 5);
            bst.InsertOrUpdate(7, 7);
            bst.InsertOrUpdate(8, 8);
            remove = bst.Remove(9);
            Assert.IsFalse(remove);
            remove = bst.Remove(5);
            Assert.IsTrue(remove);
            var arr = new int[7];
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) => arr[i++] = k);
            var arr1 = new int[7];
            i = 0;
            bst.Traverse(TraverseType.Preorder, (k, d) => arr1[i++] = k);
            foreach (var i1 in arr1)
            {
                Console.Write(i1);
                Console.Write(" ");
            }
            Console.WriteLine();
            foreach (var i1 in arr)
            {
                Console.Write(i1);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
