// detail: https://atcoder.jp/contests/abc024/submissions/6214472
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var ndr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ndr[0];
        var d = ndr[1];
        var k = ndr[2];
        var moves = Enumerable.Repeat(0, d).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int[] place = new int[k];
        int[] goal = new int[k];
        int[] whenReached = new int[k];
        for (int i = 0; i < k; i++)
        {
            var st = Console.ReadLine().Split().Select(int.Parse).ToArray();
            place[i] = st[0];
            goal[i] = st[1];
        }

        int day = 0;
        foreach (var move in moves)
        {
            day++;
            for (int i = 0; i < k; i++)
            {
                if (whenReached[i] != 0) continue;
                if (move[0] <= place[i] && place[i] <= move[1])
                {
                    if (move[0] <= goal[i] && goal[i] <= move[1])
                    {
                        whenReached[i] = day;
                        continue;
                    }
                    if (place[i] < goal[i])
                    {
                        place[i] = move[1];
                    }
                    if (goal[i] < place[i])
                    {
                        place[i] = move[0];
                    }
                }
            }
        }
        Console.WriteLine(string.Join("
", whenReached));
    }
}
