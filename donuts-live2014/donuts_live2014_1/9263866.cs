// detail: https://atcoder.jp/contests/donuts-live2014/submissions/9263866
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n % 2 == 1)
        {
            Console.WriteLine("error");
            return;
        }
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        for (int i = 0; i < n; i += 2)
        {
            res += a[i + 1] - a[i];
        }
        Console.WriteLine(res);
    }
}
