// detail: https://atcoder.jp/contests/ddcc2020-qual/submissions/8575441
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        var k = hwk[2];
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        var res = Enumerable.Repeat(0, h).Select(_ => new int[w]).ToArray();
        int[] firstArr = null;
        int[] curArr = null;
        int id = 0;
        for (int i = 0; i < map.Length; i++)
        {
            if (!map[i].Contains('#'))
            {
                res[i] = curArr;
                continue;
            }
            bool isFirst = true;
            id++;
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '#')
                {
                    if (isFirst) isFirst = false;
                    else id++;
                }
                res[i][j] = id;
            }
            if (firstArr == null) firstArr = res[i];
            curArr = res[i];
        }
        for (int i = 0; i < res.Length; i++)
        {
            if (res[i] != null) break;
            res[i] = firstArr;
        }

        Console.WriteLine(string.Join("
", res.Select(x => string.Join(" ", x))));
    }
}
