// detail: https://atcoder.jp/contests/agc033/submissions/5258313
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[,] map = new bool[hw[0], hw[1]];
        for (int i = 0; i < hw[0]; i++)
        {
            for (int j = 0; j < hw[1]; j++)
            {
                map[i, j] = Read();
            }
        }
        List<Point> points = new List<Point>();
        for (int i = 0; i < hw[0]; i++)
            for (int j = 0; j < hw[1]; j++)
                if (map[i, j])
                {
                    points.Add(new Point() { y = i + 1, x = j });
                    points.Add(new Point() { y = i, x = j + 1 });
                    points.Add(new Point() { y = i - 1, x = j });
                    points.Add(new Point() { y = i, x = j - 1 });
                }
        int step = 0;
        while (true)
        {
            bool update = false;
            List<Point> newpoints = new List<Point>();
            foreach (var point in points)
            {
                int i = point.y;
                int j = point.x;
                if (i < 0 || hw[0] <= i || j < 0 || hw[1] <= j || map[i, j]) continue;
                update = true;
                map[i, j] = true;
                newpoints.Add(new Point() { y = i + 1, x = j });
                newpoints.Add(new Point() { y = i, x = j + 1 });
                newpoints.Add(new Point() { y = i - 1, x = j });
                newpoints.Add(new Point() { y = i, x = j - 1 });
            }
            if (newpoints.Count == 0) break;
            step++;
            points = newpoints;
        }
        Console.WriteLine(step);
    }
    struct Point
    {
        public int y;
        public int x;
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool Read()
    {
        int res = 0;
        int next = In.Read();
        while (46 != next && next != 35) next = In.Read();
        return next == '#';
    }
}
