// detail: https://atcoder.jp/contests/abc018/submissions/6216972
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
        var rck = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rck[0];
        var c = rck[1];
        var k = rck[2];
        List<Tuple<int, int>> deadList = new List<Tuple<int, int>>();
        bool[,] deadArea = new bool[r, c];
        for (int i = 0; i < r; i++)
        {
            string s = Console.ReadLine();
            for (int j = 0; j < c; j++)
            {
                deadArea[i, j] = s[j] == 'x';
                if (deadArea[i, j])
                {
                    deadList.Add(new Tuple<int, int>(i, j));
                }
            }
        }
        for (int i = 1; i < k; i++)
        {
            List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
            foreach (var deadPlace in deadList)
            {
                if (1 <= deadPlace.Item1 && !deadArea[deadPlace.Item1 - 1, deadPlace.Item2])
                {
                    deadArea[deadPlace.Item1 - 1, deadPlace.Item2] = true;
                    newList.Add(new Tuple<int, int>(deadPlace.Item1 - 1, deadPlace.Item2));
                }
                if (deadPlace.Item1 < r - 1 && !deadArea[deadPlace.Item1 + 1, deadPlace.Item2])
                {
                    deadArea[deadPlace.Item1 + 1, deadPlace.Item2] = true;
                    newList.Add(new Tuple<int, int>(deadPlace.Item1 + 1, deadPlace.Item2));
                }
                if (1 <= deadPlace.Item2 && !deadArea[deadPlace.Item1, deadPlace.Item2 - 1])
                {
                    deadArea[deadPlace.Item1, deadPlace.Item2 - 1] = true;
                    newList.Add(new Tuple<int, int>(deadPlace.Item1, deadPlace.Item2 - 1));
                }
                if (deadPlace.Item2 < c - 1 && !deadArea[deadPlace.Item1, deadPlace.Item2 + 1])
                {
                    deadArea[deadPlace.Item1, deadPlace.Item2 + 1] = true;
                    newList.Add(new Tuple<int, int>(deadPlace.Item1, deadPlace.Item2 + 1));
                }
            }
            deadList = newList;
        }
        int res = 0;
        for (int i = k - 1; i < r - k + 1; i++)
            for (int j = k - 1; j < c - k + 1; j++)
                if (!deadArea[i, j]) res++;
        Console.WriteLine(res);
    }
}
