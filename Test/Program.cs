using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----insertion sort-----");
            var ret = Algorithm.Sort.InsertionSort(new[] { 15 });
            Output(ret);
            ret = Algorithm.Sort.InsertionSort(new[] { 10, 10, 10 });
            Output(ret);
            ret = Algorithm.Sort.InsertionSort(new[] { 3, 1, 2 });
            Output(ret);
            ret = Algorithm.Sort.InsertionSort(new[] { 1, 2, 3 });
            Output(ret);
            ret = Algorithm.Sort.InsertionSort(new[] { 3, 2, 1 });
            Output(ret);

            Console.WriteLine("----merge sort-----");
            ret = Algorithm.Sort.MergeSort(new[] { 1, 3, 2 });
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 7, 6, 5, 4, 3, 2, 1 });
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 99, 10, 9, 8, 100 });
            Output(ret);

            Console.WriteLine("----quicksort-----");
            ret = Algorithm.Sort.QuickSort_Native(new[] { 1 });
            Output(ret);
            ret = Algorithm.Sort.QuickSort_Native(new[] { 1, 2 });
            Output(ret);
            ret = Algorithm.Sort.QuickSort_Native(new[] { 1, 1 });
            Output(ret);
            ret = Algorithm.Sort.QuickSort_Native(new[] { 1, 2, 2, 3, 3, 4 });
            Output(ret);
            ret = Algorithm.Sort.QuickSort_Native(new[] { 4, 4, 3, 3, 2, 1, 1 });
            Output(ret);
            ret = Algorithm.Sort.QuickSort_Native(new[] { 7, 3, 9, 4, 0, 1, 5 });
            Output(ret);

            Console.WriteLine("----bubble sort-----");
            ret = Algorithm.Sort.BubbleSort(new[] { 1 });
            Output(ret);
            ret = Algorithm.Sort.BubbleSort(new[] { 1, 2 });
            Output(ret);
            ret = Algorithm.Sort.BubbleSort(new[] { 1, 1 });
            Output(ret);
            ret = Algorithm.Sort.BubbleSort(new[] { 1, 2, 2, 3, 3, 4 });
            Output(ret);
            ret = Algorithm.Sort.BubbleSort(new[] { 4, 4, 3, 3, 2, 1, 1 });
            Output(ret);
            ret = Algorithm.Sort.BubbleSort(new[] { 7, 3, 9, 4, 0, 1, 5 });
            Output(ret);

            Console.WriteLine("----heapsort-----");
            ret = Algorithm.Sort.HeapSort(new[] { 1 });
            Output(ret);
            ret = Algorithm.Sort.HeapSort(new[] { 1, 2 });
            Output(ret);
            ret = Algorithm.Sort.HeapSort(new[] { 3,2,1});
            Output(ret);
            ret = Algorithm.Sort.HeapSort(new[] { 1, 2, 2, 3, 3, 4 });
            Output(ret);
            ret = Algorithm.Sort.HeapSort(new[] { 4, 4, 3, 3, 2, 1, 1 });
            Output(ret);
            ret = Algorithm.Sort.HeapSort(new[] { 7, 3, 9, 4, 0, 1, 5 });
            Output(ret);
            Console.ReadKey();
        }

        static void Output<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
