// detail: https://atcoder.jp/contests/joi2019yo/submissions/6122126
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var coinPerWeek = abc[0] * 7 + abc[1];
        var day = (abc[2] / coinPerWeek) * 7;
        abc[2] -= (abc[2] / coinPerWeek) * coinPerWeek;
        day += Min(7, (abc[2] + abc[0] - 1) / abc[0]);
        Console.WriteLine(day);
    }
}
