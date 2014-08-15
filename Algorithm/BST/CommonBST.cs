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


        #region traverse
        private void InorderTraverse(TreeNode<TKey, TData> root, Action<TKey, TData> visitAction)
        {
            if (root != null)
            {
                InorderTraverse(root.Left, visitAction);
                visitAction(root.Key, root.Data);
                InorderTraverse(root.Right, visitAction);
            }
        }

        private void PreorderTraverse(TreeNode<TKey, TData> root, Action<TKey, TData> visitAction)
        {
            if (root != null)
            {
                visitAction(root.Key, root.Data);
                PreorderTraverse(root.Left, visitAction);
                PreorderTraverse(root.Right, visitAction);
            }
        }

        private void PostorderTraverse(TreeNode<TKey, TData> root, Action<TKey, TData> visitAction)
        {
            if (root != null)
            {
                PostorderTraverse(root.Left, visitAction);
                PostorderTraverse(root.Right, visitAction);
                visitAction(root.Key, root.Data);
            }
        }
        #endregion

        private TreeNode<TKey, TData> FindNode(TKey key,bool createIfNotFound = false)
        {
            var cur = _root;
            var cmpResult = 0;
            TreeNode<TKey, TData> pre = null;
            while (cur != null && (cmpResult = _comparer.Compare(key, cur.Key)) != 0)
            {
                pre = cur;
                cur = cmpResult > 0 ? cur.Right : cur.Left;
            }
            if (cur == null && createIfNotFound)
            {
                cur = new TreeNode<TKey, TData>(key,default(TData));
                if (_root == null)
                {
                    _root = cur;
                }
                else
                {
                    cur.Parent = pre;
                    if (cmpResult > 0)
                    {
                        pre.Right = cur;
                    }
                    else
                    {
                        pre.Left = cur;
                    }
                }
            }
            return cur;
        }

        private bool IsLeaf(TreeNode<TKey, TData> node)
        {
            return node.Left == null && node.Right == null;
        }

        /// <summary>
        /// 将<see cref="child"/>与<see cref="node"/>的父节点连接
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="child">The child.</param>
        private void ConcatWithParent(TreeNode<TKey, TData> node, TreeNode<TKey, TData> child)
        {
            if (node.Parent == null)//父节点为null,说明是根节点
            {
                _root = child;
            }
            else if (node.Parent.Left == node)
            {
                node.Parent.Left = child;
            }
            else
            {
                node.Parent.Right = child;
            }
        }

        public void Clear()
        {
            _root = null;
        }

        public bool IsEmpty()
        {
            return _root == null;
        }

        public void InsertOrUpdate(TKey key, TData data)
        {
            var node = FindNode(key, true);
            node.Data = data;
        }

        public bool Remove(TKey key)
        {
            var node = FindNode(key);
            if (node == null)
            {
                return false;
            }
            
            if (IsLeaf(node))
            {
                ConcatWithParent(node,null);
                return true;
            }
            var leftNull = false;
            if ( (leftNull = (node.Left == null)) || node.Right == null)//node为单支节点
            {
                ConcatWithParent(node, leftNull ? node.Right : node.Left);
                return true;
            }

            var successor = node.Right;//找到node的后继节点,后继节点是node右子树中key最小的节点
            while (successor.Left != null)
            {
                successor = successor.Left;
            }
            node.Key = successor.Key;
            node.Data = successor.Data;
            successor.Parent.Left = successor.Right;
            return true;
        }

        public bool TryGetData(TKey key, out TData data)
        {
            data = default(TData);
            var node = FindNode(key);

            if (node == null)
            {
                return false;
            }
            data = node.Data;
            return true;
        }

        public void Traverse(TraverseType traverseType, Action<TKey, TData> visitAction)
        {
            switch (traverseType)
            {
                case TraverseType.Inorder:
                    InorderTraverse(_root, visitAction);
                    break;
                case TraverseType.Preorder:
                    PreorderTraverse(_root, visitAction);
                    break;
                case TraverseType.Postorder:
                    PostorderTraverse(_root, visitAction);
                    break;
                default:
                    InorderTraverse(_root, visitAction);
                    break;
            }
        }
    }
}
