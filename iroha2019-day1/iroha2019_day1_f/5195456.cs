// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5195456
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var factors = Factors(nk[0]).ToArray().OrderBy(x => x).ToArray();
        if(factors.Length < nk[1])
        {
            Console.WriteLine(-1);
            return;
        }
        List<long> res = new List<long>();
        res.AddRange(factors.Take(nk[1] - 1));
        res.Add(factors.Skip(nk[1] - 1).Aggregate(1L, (x, y) => x * y));
        Console.WriteLine(string.Join(" ", res));

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
