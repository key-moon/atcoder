// detail: https://atcoder.jp/contests/arc100/submissions/6237024
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var accum = new long[n + 1];
        long res = long.MaxValue;
        for (int i = 0; i < a.Length; i++) accum[i + 1] = accum[i] + a[i];
        for (int i = 2; i <= n - 2; i++)
        {
            int valid, invalid;
            valid = 0;
            invalid = i;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (accum[mid] * 2 < accum[i]) valid = mid;
                else invalid = mid;
            }
            var separator1 = valid;
            var separator2 = i;

            valid = i;
            invalid = n;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if ((accum[mid] - accum[i]) * 2 < (accum[n] - accum[i])) valid = mid;
                else invalid = mid;
            }
            var separator3 = valid;

            res = Min(res, CalcScore(accum, separator1, separator2, separator3));
            res = Min(res, CalcScore(accum, separator1 + 1, separator2, separator3));
            res = Min(res, CalcScore(accum, separator1, separator2, separator3 + 1));
            res = Min(res, CalcScore(accum, separator1 + 1, separator2, separator3 + 1));
        }
        Console.WriteLine(res);
    }

    static long CalcScore(long[] accum, int s1, int s2, int s3)
    {
        if (0 >= s1 || s1 >= s2 || s2 >= s3 || s3 >= accum.Length - 1) return long.MaxValue;
        var scores = new long[] { accum[s1], accum[s2] - accum[s1], accum[s3] - accum[s2], accum.Last() - accum[s3] };
        return scores.Max() - scores.Min();
    }
}
