//****************************************************************************************************
//ClassName:       Sort
//Author:          Xiaoying Wang
//Guid:		       7cdbf5ef-dee9-4495-a550-84f351bd52f2
//DateTime:        2014/8/5 14:14:18
//Email Address:   wangxiaoying@gedu.org
//FileName:        Sort
//CLR Version:     4.0.30319.18444
//Machine Name:    WXY-PC
//Namespace:       Algorithm
//Function:                
//Description:    Implementation of popular sort algorithms, include insertion sort, quicksort, merge sort and heapsort
//****************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Sort
    {
        private static void Guard<T>(T[] arr, ref IComparer<T> comparer)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException();
            }
            var tType = typeof(T);
            if (comparer == null && (typeof(IComparable<T>).IsAssignableFrom(tType)) ||
                typeof(IComparable).IsAssignableFrom(tType))
            {
                comparer = Comparer<T>.Default;
            }
        }
        #region insertion sort
        public static T[] InsertionSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            var ret = new T[arr.Length];
            ret[0] = arr[0];
            var count = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = count - 1; j >= -1; j--)
                {
                    if (j == -1 || comparer.Compare(arr[i], ret[j]) >= 0)
                    {
                        ret[j+1] = arr[i];
                        count++;
                        break;
                    }
                    ret[j + 1] = ret[j];
                }
            }

            return ret;
        }
        #endregion

        public static T[] MergeSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            return null;
        }

        public static T[] QuickSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            return null;
        }

        public static T[] HeapSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            return null;
        }
    }
}
