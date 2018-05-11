// detail: https://atcoder.jp/contests/cf16-relay-open/submissions/2492558
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int curTime = 0;
        int[] wTime = new int[86400];
        for (int i = 0; i < n; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            curTime = (curTime + ab[0]) % wTime.Length;
            wTime[curTime]++;
            curTime = (curTime + ab[1]) % wTime.Length;
        }

        long[] ruisekiwa = new long[wTime.Length * 2];
        for (int i = 1; i < ruisekiwa.Length - 1; i++)
        {
            ruisekiwa[i + 1] = ruisekiwa[i] + wTime[(i - 1) % wTime.Length];
        }
        long max = 0;
        for (int i = 0; i < ruisekiwa.Length - 10802; i++)
        {
            max = Max(max, ruisekiwa[i + 10801] - ruisekiwa[i]);
        }
        Console.WriteLine(max);
    }
}
