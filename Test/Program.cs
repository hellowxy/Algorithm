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
            //var ret = Algorithm.Sort.InsertionSort(new[] { 15 });
            //Output(ret);
            //ret = Algorithm.Sort.InsertionSort(new[] { 10, 10, 10 });
            //Output(ret);
            //ret = Algorithm.Sort.InsertionSort(new[] { 3, 1, 2 });
            //Output(ret);

            //ret = Algorithm.Sort.InsertionSort(new[] { 1, 2, 3 });
            //Output(ret);
            //ret = Algorithm.Sort.InsertionSort(new[] { 3, 2, 1 });
            //Output(ret);


           
           var ret = Algorithm.Sort.MergeSort(new[] { 1 ,3,2});
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 1 ,2,3,4,5,6,7});
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 7,6,5,4,3,2,1 });
            Output(ret);
            ret = Algorithm.Sort.MergeSort(new[] { 99,10,9,8,100 });
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
