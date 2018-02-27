// detail: https://atcoder.jp/contests/abc062/submissions/2141523
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] hw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res;
        if ((hw[1] % 3) * (hw[0] % 3) == 0)
        {
            res = 0;
        }
        else
        {
            long[] a = { hw[0] / 3 * hw[1], (hw[0] - hw[0] / 3) * (hw[1] / 2), (hw[0] - hw[0] / 3) * (hw[1] - hw[1] / 2) };
            long[] b = { (hw[0] / 3 + 1) * hw[1], (hw[0] - (hw[0] / 3 + 1)) * (hw[1] / 2), (hw[0] - (hw[0] / 3 + 1)) * (hw[1] - hw[1] / 2) };

            long[] c = { hw[1] / 3 * hw[0], (hw[1] - hw[1] / 3) * (hw[0] / 2), (hw[1] - hw[1] / 3) * (hw[0] - hw[0] / 2) };
            long[] d = { (hw[1] / 3 + 1) * hw[0], (hw[1] - (hw[1] / 3 + 1)) * (hw[0] / 2), (hw[1] - (hw[1] / 3 + 1)) * (hw[0] - hw[0] / 2) };
            //Console.WriteLine($"{a.Max() - a.Min()} {b.Max() - b.Min()} {c.Max() - c.Min()} {d.Max() - d.Min()}");
            res = Math.Min(hw.Select(x => x == 2 ? int.MaxValue : x).Min(), Math.Min(Math.Min(a.Max() - a.Min(), b.Max() - b.Min()), Math.Min(c.Max() - c.Min(), d.Max() - d.Min())));
        }
        Console.WriteLine(res);
    }
}
