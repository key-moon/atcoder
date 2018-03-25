// detail: https://atcoder.jp/contests/arc093/submissions/2256254
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = 0;
        sum += Math.Abs(a[0]);
        for (int i = 1; i < a.Length; i++)
        {
            sum += Math.Abs(a[i - 1] - a[i]);
        }
        sum += Math.Abs(a.Last());
        Console.WriteLine(sum - minusDist(0,a[0],a[1]));
        for (int i = 1; i < a.Length - 1; i++)
        {
            Console.WriteLine(sum - minusDist(a[i - 1], a[i], a[i + 1]));
        }
        Console.WriteLine(sum - minusDist(a[a.Length - 2], a[a.Length - 1], 0));
    }
    static int minusDist(int now, int next, int nextnext)
    {
        int res = 0;
        res += Math.Abs(now - next);
        res += Math.Abs(next - nextnext);
        res -= Math.Abs(now - nextnext);
        return res;
    }
}
