//****************************************************************************************************
//ClassName:       CommonBST
//Author:          Xiaoying Wang
//Guid:		       a7a28b50-2a36-47ca-8f50-dcd55b6df993
//DateTime:        2014/8/12 13:46:02
//Email Address:   wangxiaoying@gedu.org
//FileName:        CommonBST
//CLR Version:     4.0.30319.18444
//Machine Name:    WXY-PC
//Namespace:       Algorithm.BST
//Function:                
//Description:     Common binary search tree, there is no balance operation while updating the tree.
//****************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BST
{
    public class CommonBST<TKey, TData>
    {
        private TreeNode<TKey, TData> _root;
        private readonly IComparer<TKey> _comparer;

        public CommonBST(IComparer<TKey> comparer = null)
        {
            Common.GuardComparer(ref comparer);
            _comparer = comparer;
            _root = null;
        }

        private TreeNode<TKey, TData> FindNode(TKey key)
        {
            return null;
        }


        public void Insert(TKey key, TData data)
        {
            var node = new TreeNode<TKey, TData>(key, data);
            if (_root == null)
            {
                _root = node;
                return;
            }
            var cur = _root;
            TreeNode<TKey, TData> pre = null;
            var insertLeft = false;
            while (cur != null)
            {
                pre = cur;
                if (_comparer.Compare(cur.Key, node.Key) > 0)
                {
                    cur = cur.Left;
                    insertLeft = true;
                }
                else
                {
                    cur = cur.Right;
                    insertLeft = false;
                }
            }
            if (insertLeft)
            {
                pre.Left = node;
            }
            else
            {
                pre.Right = node;
            }
        }

        public bool Delete(TKey key)
        {

        }

        public bool TryGetData(TKey key, out TData data)
        {
            data = default(TData);
            return false;
        }

        public void Traverse(TraverseType traverseType, Action<TKey, TData> traverseAction)
        {
            if (_root == null)
            {
                return;
            }
            var cur = _root;
            while (true)
            {
                
            }
            switch (traverseType)
            {
                case TraverseType.Inorder:
                    break;
                case TraverseType.Preorder:
                    break;
                case TraverseType.Postorder:
                    break;
                default:
                    break;
            }
        }

        private void InorderTraverse()
        { }
    }
}
