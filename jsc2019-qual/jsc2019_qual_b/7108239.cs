// detail: https://atcoder.jp/contests/jsc2019-qual/submissions/7108239
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        long k = nk[1];
        long res = 0;
        var perm = ((k - 1) * k / 2) % 1000000007;
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        res += a.Sum(x => (a.Count(y => y > x) * perm) % 1000000007) % 1000000007;
        res += (a.Select((x, y) => a.Take(y).Count(z => z > x) % 1000000007).Sum() % 1000000007) * k;
        res %= 1000000007;
        Console.WriteLine(res);
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
