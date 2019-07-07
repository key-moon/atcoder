// detail: https://atcoder.jp/contests/abc133/submissions/6272130
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var lr = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (lr[1] - lr[0] >= 2019) Console.WriteLine(0);
        else
        {
            long min = 2018;
            for (long i = lr[0]; i <= lr[1]; i++)
            {
                for (long j = i + 1; j <= lr[1]; j++)
                {
                    min = Min(min, i * j % 2019);
                }
            }
            Console.WriteLine(min);
        }

    }
}
