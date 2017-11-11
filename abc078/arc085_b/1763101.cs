// detail: https://atcoder.jp/contests/abc078/submissions/1763101
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            //Yの初期手札
            int W = Convert.ToInt32(input[2]);

            input = Console.ReadLine().Split(' ');

            //カード列
            int[] a = new int[input.Length];
            for (int i = 0; i < input.Length; i++) a[i] = Convert.ToInt32(input[i]);

            int result = (a.Length >= 2) ? Math.Max(Math.Abs(a[a.Length - 1] - W), Math.Abs(a[a.Length - 2] - a[a.Length - 1])) : Math.Abs(a[a.Length - 1] - W);

            Console.WriteLine(result);
        }
    }
}
