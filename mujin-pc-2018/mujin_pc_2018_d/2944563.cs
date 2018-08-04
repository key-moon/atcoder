// detail: https://atcoder.jp/contests/mujin-pc-2018/submissions/2944563
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //  possible:1
        //impossible:-1
        //       idk:0
        int[][] a = Enumerable.Repeat(0, 1001).Select(_ => new int[1001]).ToArray();
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (a[i][j] != 0) continue;
                List<int> hashL = new List<int>();
                List<Tuple<int, int>> l = new List<Tuple<int, int>>();
                l.Add(new Tuple<int, int>(i, j));
                bool b;
                while (true)
                {
                    Tuple<int, int> ltup = l.Last();
                    int x = ltup.Item1;
                    int y = ltup.Item2;
                    if (x < y) x = rev(x);
                    else y = rev(y);
                    Tuple<int, int> tup = new Tuple<int, int>(Abs(x - y), Min(x, y));
                    int hash = GetHash(tup);
                    if (tup.Item1 == 0 || tup.Item2 == 0)
                    {
                        b = false;
                        break;
                    }
                    if (hashL.Contains(hash))
                    {
                        b = true;
                        break;
                    }
                    if (a[tup.Item1][tup.Item2] != 0 || a[tup.Item2][tup.Item1] != 0)
                    {
                        b = a[tup.Item1][tup.Item2] == 1;
                        break;
                    }
                    hashL.Add(hash);
                    l.Add(tup);
                }
                foreach (var item in l)
                {
                    a[item.Item1][item.Item2] = b ? 1 : -1;
                    a[item.Item2][item.Item1] = b ? 1 : -1;
                }
            }
        }/*
        string s = string.Join("
", a.Select(x => string.Join("", x.Select(y => y == 1 ? "1" : "0"))));
        using (StreamWriter writer = new StreamWriter(@"C:\Userskikuchi\Desktopi1333.txt"))
        {
            writer.WriteLine(s);
        }*/
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 0; i <= nm[0]; i++)
        {
            for (int j = 0; j <= nm[1]; j++)
            {
                if (a[i][j] == 1) res++;
            }
        }
        Console.WriteLine(res);
    }
    static int rev(int a)
    {
        if (a / 10 == 0) return a;
        if (a / 100 == 0) return (a % 10) * 10 + a / 10;
        if (a / 1000 == 0) return (a % 10) * 100 + ((a / 10) % 10) * 10 + (a / 100);
        throw new Exception();
    }
    static int GetHash(Tuple<int, int> t) => GetHash(t.Item1, t.Item2);
    static int GetHash(int a,int b)
    {
        return Max(a, b) * 1333 + Min(a, b);
    }
    
}
