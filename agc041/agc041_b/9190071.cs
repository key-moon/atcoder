// detail: https://atcoder.jp/contests/agc041/submissions/9190071
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nmvp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmvp[0];
        var m = nmvp[1];
        var v = nmvp[2];
        var p = nmvp[3];
        var a = Console.ReadLine().Split().Select(long.Parse).OrderByDescending(x => x).ToArray();
        //m回v個 +1 最終的にtop p
        //単調性があるため二分探索可能
        var valid = 0;
        var invalid = n;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (mid.CanAdopt(a, m, v, p)) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(invalid);
    }
    static bool CanAdopt(this int ind, long[] problems, long m, long v, long p)
    {
        long maxScore = problems[ind] + m;
        v--;

        int i = 0;
        //targetより大きいのがp個以上あったら
        for (; i < problems.Length; i++)
            if (problems[i] <= maxScore) break;

        int largeProblemCount = i;
        if (p <= largeProblemCount) return false;
        //target以上のには投票して構わない=投票回数を個数分減らせる
        v -= largeProblemCount;

        //問題はp以下の雑魚 とりあえず最初の複数個は全部埋める 上がp-1個になった瞬間終わり
        for (; i < problems.Length && largeProblemCount < p - 1 && 0 < v; i++)
        {
            if (ind == i) continue;
            if (maxScore < problems[i] + m) largeProblemCount++;
            v--;
        }
        long votes = 0;
        //pに揃える
        for (; i < problems.Length; i++)
        {
            if (ind == i) continue;
            votes += Min(m, Max(0, maxScore - problems[i]));
        }
        return m * v <= votes;
    }
}
