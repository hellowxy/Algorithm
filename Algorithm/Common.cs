//****************************************************************************************************
//ClassName:       Common
//Author:          Xiaoying Wang
//Guid:		       a2999dc4-5d9b-4145-ab09-d37009cda29b
//DateTime:        2014/8/12 10:35:47
//Email Address:   wangxiaoying@gedu.org
//FileName:        Common
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
    public static class Common
    {
        public static void GuardArrayNotEmpty<T>(T[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException();
            }
        }

        public static void GuardComparer<T>(ref IComparer<T> comparer)
        {
            if (comparer != null)
            {
                return;
            }
            var tType = typeof(T);
            if ((typeof(IComparable<T>).IsAssignableFrom(tType)) ||
                typeof(IComparable).IsAssignableFrom(tType))
            {
                comparer = Comparer<T>.Default;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
