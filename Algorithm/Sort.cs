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
            else
            {
                throw new ArgumentException();
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
                        ret[j + 1] = arr[i];
                        count++;
                        break;
                    }
                    ret[j + 1] = ret[j];
                }
            }

            return ret;
        }
        #endregion

        #region merge sort
        public static T[] MergeSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            var ret = MergeSort(arr, 0, arr.Length - 1, comparer);
            return ret;
        }

        private static T[] MergeSort<T>(T[] arr, int startIndex, int endIndex, IComparer<T> comparer)
        {
            if (startIndex == endIndex)//只有一个元素直接返回
            {
                return new T[] { arr[startIndex] };
            }
            var length = endIndex - startIndex + 1;
            var midIndex = startIndex + length / 2 - 1;
            var a1 = MergeSort(arr, startIndex, midIndex, comparer);
            var a2 = MergeSort(arr, midIndex + 1, endIndex, comparer);
            var ret = Merge(a1, a2, comparer);
            return ret;
        }

        private static T[] Merge<T>(T[] arr1, T[] arr2, IComparer<T> comparer)
        {
            var ret = new T[arr1.Length + arr2.Length];
            var i = 0;
            var j = 0;
            T val = default(T);
            do
            {
                if (i == arr1.Length)
                {
                    val = arr2[j++];
                }
                else if (j == arr2.Length)
                {
                    val = arr1[i++];
                }
                else
                {
                    if (comparer.Compare(arr1[i], arr2[j]) > 0)
                    {
                        val = arr2[j++];
                    }
                    else
                    {
                        val = arr1[i++];
                    }
                }
                ret[i + j - 1] = val;
            } while (i < arr1.Length || j < arr2.Length);
            return ret;
        }



        #endregion

        #region quicksort
        public static T[] QuickSort_Native<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            Quick(arr, 0, arr.Length - 1, comparer);
            return arr;
        }

        private static void Quick<T>(T[] arr, int startIndex, int endIndex, IComparer<T> comparer)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            var pivotIndex = Partition(arr, startIndex, endIndex, comparer);
            Quick<T>(arr, startIndex, pivotIndex - 1, comparer);
            Quick<T>(arr, pivotIndex + 1, endIndex, comparer);
        }

        private static int Partition<T>(T[] arr, int startIndex, int endIndex, IComparer<T> comparer)
        {
            var pivotIndex = startIndex;
            var pivotValue = arr[pivotIndex];//选取待处理数组的第一个元素作为pivot
            var i = startIndex + 1;
            var j = endIndex;
            T temp = default(T);
            while (true)
            {
                while (i <= j && comparer.Compare(arr[i], pivotValue) <= 0)
                {
                    i++;
                }

                while (j >= i && comparer.Compare(arr[j], pivotValue) >= 0)
                {
                    j--;
                }

                if (i > j)
                {
                    arr[pivotIndex] = arr[i - 1];
                    arr[i - 1] = pivotValue;
                    return i - 1;
                }
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }

        }

        #endregion

        #region heapsort

        public static T[] HeapSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Guard(arr, ref comparer);
            return null;
        }
        #endregion
    }
}
