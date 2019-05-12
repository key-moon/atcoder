// detail: https://atcoder.jp/contests/keyence2019/submissions/5374626
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
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] diff = a.Zip(b, (x, y) => x - y).ToArray();
        int[] amari = diff.Where(x => x > 0).OrderByDescending(x => x).ToArray();
        int[] dame = diff.Where(x => x < 0).ToArray();

        Queue<long> q = new Queue<long>();
        foreach (var item in amari) q.Enqueue((long)item);

        long currentCount = 0;
        long currentUsed = 0;
        foreach (var item in dame)
        {
            while(currentUsed + item < 0)
            {
                if(q.Count == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                currentUsed += q.Dequeue();
                currentCount++;
            }
            currentUsed += item;
            currentCount++;
        }
        Console.WriteLine(currentCount);
    }
}


static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
