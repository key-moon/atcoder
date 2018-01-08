// detail: https://atcoder.jp/contests/arc004/submissions/1955512
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        point[] p = new point[n];

        for (int i = 0; i < p.Length; i++)
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            p[i] = new point(a[0], a[1]);
        }

        int maxdist = 0;
        for (int i = 0; i < p.Length; i++)
        {
            for (int j = i + 1; j < p.Length; j++)
            {
                maxdist = Math.Max(maxdist,point.dist(p[i], p[j]));
            }
        }
        Console.WriteLine(Math.Sqrt(maxdist));
    }
    struct point
    {
        public int x;
        public int y;
        public point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public static int dist(point a,point b)
        {
            return Math.Abs(a.x - b.x) * Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y) * Math.Abs(a.y - b.y);
        }
    }
}
