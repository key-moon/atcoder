// detail: https://atcoder.jp/contests/agc031/submissions/4599225
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        //そこ始点の奴
        //一つしかない場合は、いままでそれが含まれていた確率が
        long res = 0;
        long[] count = Enumerable.Repeat(1L, 26).ToArray();
        int i = 0;
        foreach (var c in s)
        {
            var val = c - 'a';
            res += count.Where((x,y) => y != val).Aggregate(1L, (x, y) => (x * y) % 1000000007);
            res %= 1000000007;
            count[val]++;
        }
        Console.WriteLine(res);
    }

    static long Power(long n, long m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return res;
    }
}
