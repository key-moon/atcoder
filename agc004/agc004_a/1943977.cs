// detail: https://atcoder.jp/contests/agc004/submissions/1943977
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        bool isexistseven = a[0] % 2 == 0 || a[1] % 2 == 0 || a[2] % 2 == 0;
        if (isexistseven)
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine((long)a[0] * a[1]);
        }
    }
}
