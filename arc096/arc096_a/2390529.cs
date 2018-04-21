// detail: https://atcoder.jp/contests/arc096/submissions/2390529
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        double[] abcxy = Console.ReadLine().Split().Select(double.Parse).ToArray();
        if (abcxy[0] > abcxy[2] * 2)
        {
            abcxy[0] = abcxy[2] * 2;
        }
        if (abcxy[1] > abcxy[2] * 2)
        {
            abcxy[1] = abcxy[2] * 2;
        }
        if (abcxy[0] + abcxy[1] < abcxy[2] * 2)
        {
            abcxy[2] = (abcxy[0] + abcxy[1]) / 2;
        }
        double min = Min(abcxy[3], abcxy[4]);
        Console.WriteLine(min * abcxy[2] * 2 + Ceiling(abcxy[3] > abcxy[4] ? (abcxy[3] - abcxy[4]) * abcxy[0] : (abcxy[4] - abcxy[3]) * abcxy[1]));
    }
}
