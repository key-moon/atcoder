// detail: https://atcoder.jp/contests/otemae2019/submissions/6647690
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var mnk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] map = new int[mnk[0]];
        foreach (var elem in x)
        {
            map[elem - 1]++;
        }
        int max = 0;
        for (int i = 0; i < mnk[0]; i++)
        {
            int count = map[i];
            for (int j = 1; j <= mnk[2]; j++)
            {
                if ((0 <= i - j && map[i - j] != 0) || (i + j < map.Length && map[i + j] != 0))
                    count++;
            }
            max = Max(max, count);
        }
        Console.WriteLine(max);
    }
}
