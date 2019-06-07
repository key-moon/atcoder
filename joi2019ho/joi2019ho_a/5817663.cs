// detail: https://atcoder.jp/contests/joi2019ho/submissions/5817663
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine()).ToArray();
        var accumlateOrb = Enumerable.Repeat(0, hw[0] + 1).Select(_ => new long[hw[1] + 1]).ToArray();
        var accumlateIngot = Enumerable.Repeat(0, hw[0] + 1).Select(_ => new long[hw[1] + 1]).ToArray();
        long res = 0;
        for (int i = hw[0] - 1; i >= 0; i--)
        {
            for (int j = hw[1] - 1; j >= 0; j--)
            {
                accumlateOrb[i][j] = accumlateOrb[i][j + 1];
                accumlateIngot[i][j] = accumlateIngot[i + 1][j];
                if (map[i][j] == 'J') res += accumlateOrb[i][j] * accumlateIngot[i][j];
                if (map[i][j] == 'O') accumlateOrb[i][j]++;
                if (map[i][j] == 'I') accumlateIngot[i][j]++;
            }
        }
        Console.WriteLine(res);
    }
}
