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
            var i = 0;
            var keys = new int[] { 4, 2, 6, 1, 3, 7, 8 };
            for (; i < keys.Length; i++)
            {
                bst.InsertOrUpdate(keys[i], keys[i]);
            }

            var arr = new int[7];
            i = 0;
            bst.Traverse(TraverseType.Inorder, (k, d) => arr[i++] = k);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 6, 7, 8 }, arr);
            i = 0;
            bst.Traverse(TraverseType.Preorder, (k, d) => arr[i++] = k);
            CollectionAssert.AreEqual(new int[] { 4, 2, 1, 3, 6, 7, 8 }, arr);//通过中序遍历和先序遍历得到的结果确认树的形状
            bst.InsertOrUpdate(5, 10);
            i = 0;
            arr = new int[8];
            bst.Traverse(TraverseType.Inorder, (k, d) => arr[i++] = k);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, arr);
            i = 0;
            bst.Traverse(TraverseType.Preorder, (k, d) => arr[i++] = k);
            CollectionAssert.AreEqual(new int[] { 4, 2, 1, 3, 6, 5, 7, 8 }, arr);

            get = bst.TryGetData(5, out data);
            Assert.IsTrue(get);
            Assert.IsTrue(data == 10);

            bst.InsertOrUpdate(5, -2);
            i = 0;
            bst.Traverse(TraverseType.Preorder, (k, d) => arr[i++] = k);
            CollectionAssert.AreEqual(new int[] { 4, 2, 1, 3, 6, 5, 7, 8 }, arr);
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


        }
    }
}
