// detail: https://atcoder.jp/contests/joisc2007/submissions/6121684
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


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var res = Factors(n).GroupBy(x => x, x => x, (x, y) =>
        {
            var count = y.Count();
            long num = 0;
            while (0 < count)
            {
                num += x;
                long tmp = num;
                while (tmp % x == 0)
                {
                    count--;
                    tmp /= x;
                }
            }
            return num;
        }).Max();
        Console.WriteLine(res);
    }

    static IEnumerable<long> Factors(long n)
    {
        while (n % 2 == 0)
        {
            n /= 2;
            yield return 2;
        }
        long i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                n /= i;
                yield return i;
            }
            else i += 2;
        }
        if (n != 1) yield return n;
    }
}
