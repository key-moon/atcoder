// detail: https://atcoder.jp/contests/arc098/submissions/9297779
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var accumXor = new long[n + 1];
        var accumSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            accumSum[i + 1] = accumSum[i] + a[i];
            accumXor[i + 1] = accumXor[i] ^ a[i];
        }
        long res = 0;
        for (int i = 0; i < n; i++)
        {
            var valid = i + 1;
            var invalid = n + 1;
            while (invalid - valid > 1)
            {
                var mid = (invalid + valid) / 2;
                if (accumSum[mid] - accumSum[i] == (accumXor[mid] ^ accumXor[i])) valid = mid;
                else invalid = mid; 
            }
            res += valid - i;
        }
        Console.WriteLine(res);
    }
}
