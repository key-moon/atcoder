// detail: https://atcoder.jp/contests/abc091/submissions/6359094
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int i = 0; i < 29; i++)
        {
            long totalCount = 0;
            int lessInd1 = n;
            int moreInd1 = n;
            int moreInd2 = n;
            var mask = ((1 << i + 1) - 1);
            var orderedAUntil = a.Select(x => x & mask).ToList();
            orderedAUntil.Sort();
            var orderedBUntil = b.Select(x => x & mask).ToList();
            orderedBUntil.Sort();
            for (int j = 0; j < orderedBUntil.Count; j++)
            {
                var bElem = orderedBUntil[j];
                while (0 < lessInd1)
                {
                    if ((1 << (i + 1)) <= orderedAUntil[lessInd1 - 1] + bElem) lessInd1--;
                    else break;
                }
                while (0 < moreInd1)
                {
                    if ((1 << i) <= orderedAUntil[moreInd1 - 1] + bElem) moreInd1--;
                    else break;
                }
                while (0 < moreInd2)
                {
                    if ((1 << (i + 1)) + (1 << i) <= orderedAUntil[moreInd2 - 1] + bElem) moreInd2--;
                    else break;
                }
                totalCount += moreInd1 - lessInd1 + (moreInd2 + 1);
            }
            res |= ((totalCount & 1) << i);
        }
        Console.WriteLine(res);
    }
}
