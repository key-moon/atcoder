// detail: https://atcoder.jp/contests/abc100/submissions/2681289
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[][] xyzs = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        long max = 0;
        for (int i = 0; i <= 1; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 1; k++)
                {
                    List<Tuple<long, long[]>> a = new List<Tuple<long, long[]>>();
                    foreach (var xyz in xyzs)
                    {
                        long score = (i == 0 ? 1 : -1) * xyz[0] + (j == 0 ? 1 : -1) * xyz[1] + (k == 0 ? 1 : -1) * xyz[2];
                        a.Add(new Tuple<long, long[]>(score, xyz));
                    }
                    long s = 0;
                    for (int g = 0; g < 3; g++)
                    {
                        s += Math.Abs(a.OrderByDescending(f => f.Item1).Take(nm[1]).Sum(p => p.Item2[g]));
                    }
                    max = Math.Max(max, s);
                }
            }
        }
        Console.WriteLine(max);
    }
    
}
