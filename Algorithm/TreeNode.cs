//****************************************************************************************************
//ClassName:       TreeNode
//Author:          Xiaoying Wang
//Guid:		       7881bd7f-0b22-4479-bfe3-47b68e5311f7
//DateTime:        2014/8/12 13:47:46
//Email Address:   wangxiaoying@gedu.org
//FileName:        TreeNode
//CLR Version:     4.0.30319.18444
//Machine Name:    WXY-PC
//Namespace:       Algorithm
//Function:                
//Description:     represention of a node in a binary tree
//****************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class TreeNode<TKey,TData> 
    {
        internal TreeNode(TKey key,TData data,TreeNode<TKey,TData> left = null, TreeNode<TKey,TData> right = null)
        {
            Key = key;
            Data = data;
            Left = left;
            Right = right;
        }

        internal TKey Key { get; set; }

        internal TData Data { get; set; }

        internal TreeNode<TKey,TData> Left { get; set; }

        internal TreeNode<TKey,TData> Right { get; set; }

        internal TreeNode<TKey, TData> Parent { get; set; } 
    }
}
