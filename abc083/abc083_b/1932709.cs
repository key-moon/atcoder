// detail: https://atcoder.jp/contests/abc083/submissions/1932709
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 1; i <= a[0]; i++)
        {
            int sum = 0;
            foreach (var digit in i.ToString())
            {
                sum += digit - '0';
            }
            if (a[1] <= sum && sum <= a[2]) res += i;
        }
        Console.WriteLine(res);
    }
}
