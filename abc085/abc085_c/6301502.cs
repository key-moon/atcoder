// detail: https://atcoder.jp/contests/abc085/submissions/6301502
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
        var ny = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var y = ny[1];
        for (int i = 0; i <= ny[0]; i++)
        {
            for (int j = 0; j <= ny[0]; j++)
            {
                var remain = y - (i * 10000 + j * 5000);
                if (0 <= remain && remain % 1000 == 0 && remain / 1000 == (ny[0] - i - j))
                {
                    Console.WriteLine($"{i} {j} {remain / 1000}");
                    return;
                }
            }
        }
        Console.WriteLine("-1 -1 -1");
    }
}
