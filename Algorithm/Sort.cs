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
//Description:    Implementation of common sort algorithms, including bubble sort, insertion sort, quicksort, merge sort and heapsort
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
        #region bubble sort

        public static T[] BubbleSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Common.Guard(arr, ref comparer);
            for (int i = arr.Length; i > 1; --i)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (comparer.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        T t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }
            return arr;
        }

        #endregion

        #region insertion sort
        public static T[] InsertionSort<T>(T[] arr, IComparer<T> comparer = null)
        {
            Common.Guard(arr, ref comparer);
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
            Common.Guard(arr, ref comparer);
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
            Common.Guard(arr, ref comparer);
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
            T temp;
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
            Common.Guard(arr, ref comparer);
            BuildInitialHeap(arr, comparer);
            var len = arr.Length;
            T temp = arr[0];
            arr[0] = arr[len - 1];
            arr[len - 1] = temp;
            len--;
            while (len > 1)
            {
                Ajust(arr, 0, len - 1, comparer);
                temp = arr[0];
                arr[0] = arr[len - 1];
                arr[len - 1] = temp;
                --len;
            }

            return arr;
        }

        /// <summary>
        /// Builds the initial heap.
        /// 构造初始堆
        /// </summary>
        private static void BuildInitialHeap<T>(T[] arr, IComparer<T> comparer)
        {
            var lastNonLeafNodeIndex = arr.Length / 2 - 1;
            for (int i = lastNonLeafNodeIndex; i >= 0; --i)
            {
                Ajust(arr, i, arr.Length - 1, comparer);
            }
        }

        /// <summary>
        /// 调整堆,使其重新成为一个大顶堆
        /// </summary>
        private static void Ajust<T>(T[] arr, int rootIndex, int lastNodeIndex, IComparer<T> comparer)
        {
            while (true)
            {
                var leftChildIndex = 2 * rootIndex + 1;
                var rightChildIndex = 2 * rootIndex + 2;
                var hasLeftChild = leftChildIndex <= lastNodeIndex;
                var hasRightChild = rightChildIndex <= lastNodeIndex;
                if (!hasLeftChild || //不存在左子树,说明是叶子节点,不需要调整
                    (comparer.Compare(arr[rootIndex], arr[leftChildIndex]) >= 0 && //根节点的值大于等于左子树的根节点值
                    (!hasRightChild || comparer.Compare(arr[rootIndex], arr[rightChildIndex]) >= 0)))//不存在右子树,或者根节点值大于等于右子树根节点值,不需要调整
                {
                    return;
                }

                var rootValue = arr[rootIndex];
                var leftValue = arr[leftChildIndex];
                if (hasRightChild)//左右子树都存在
                {
                    var rightValue = arr[rightChildIndex];
                    if (comparer.Compare(rightValue, leftValue) > 0)
                    {
                        arr[rootIndex] = rightValue;
                        arr[rightChildIndex] = rootValue;
                        rootIndex = rightChildIndex;
                        continue;
                    }
                }
                arr[rootIndex] = leftValue;
                arr[leftChildIndex] = rootValue;
                rootIndex = leftChildIndex;
            }
        }
        #endregion
    }
}
