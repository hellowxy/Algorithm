//****************************************************************************************************
//ClassName:       TreeTraverseType
//Author:          Xiaoying Wang
//Guid:		       755eb82d-8abd-4910-9c21-2d6a907c5fed
//DateTime:        2014/8/12 14:52:30
//Email Address:   wangxiaoying@gedu.org
//FileName:        TreeTraverseType
//CLR Version:     4.0.30319.18444
//Machine Name:    WXY-PC
//Namespace:       Algorithm
//Function:                
//Description:    
//****************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// 树的遍历次序
    /// </summary>
    public enum TraverseType
    {
        /// <summary>
        /// 中根序遍历
        /// </summary>
        Inorder,
        /// <summary>
        /// 先根序遍历
        /// </summary>
        Preorder,
        /// <summary>
        /// 后根序遍历
        /// </summary>
        Postorder,
    }
}
