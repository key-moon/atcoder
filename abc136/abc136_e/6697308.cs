// detail: https://atcoder.jp/contests/abc136/submissions/6697308
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //総和は変わらない
        //最大値をmaxとすると、n / max<sumであればよくて
        //総和の約数の中で実現可能かを調べる
        var sum = a.Sum();
        var possibleMax = sum / n;
        var candidates = Factors(sum).OrderBy(x => x).Reverse().ToArray();
        foreach (var cand in candidates)
        {
            var mods = a.Select(x => x % cand).ToArray();
            var upCount = mods.Sum() / cand;
            var step = mods.OrderByDescending(x => x).Skip((int)upCount).Sum();
            if (step <= k)
            {
                Console.WriteLine(cand);
                return;
            }
        }
    }


    static IEnumerable<long> Factors(long n)
    {
        int i = 1;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                yield return i;
                yield return n / i;
            }
            i++;
        }
    }
}
