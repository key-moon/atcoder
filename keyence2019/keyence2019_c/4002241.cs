// detail: https://atcoder.jp/contests/keyence2019/submissions/4002241
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //全てに合格
        long[] a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] b = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long[] diff = a.Zip(b, (x, y) => x - y).ToArray();
        long[] amari = diff.Where(x => x > 0).OrderByDescending(x => x).ToArray();
        long badsum = -diff.Where(x => x < 0).Sum();

        int res = diff.Where(x => x < 0).Count();
        if (badsum <= 0)
        {
            Console.WriteLine(res);
            return;
        }
        foreach (var item in amari)
        {
            badsum -= item;
            res++;
            if(badsum <= 0)
            {
                Console.WriteLine(res);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}


static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
