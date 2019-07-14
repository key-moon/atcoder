// detail: https://atcoder.jp/contests/agc018/submissions/6370737
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        canUse = new bool[nm[1]];
        count = new int[nm[1]];
        var possible = nm[0];
        var impossible = 0;
        while (possible - impossible > 1)
        {
            var mid = (possible + impossible) / 2;
            if (Judge(a, mid)) possible = mid;
            else impossible = mid;
        }
        Console.WriteLine(possible);
    }

    static bool[] canUse;
    static int[] count;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool Judge(int[][] a, int target)
    {
        int canUseCount = canUse.Length;
        int[] indexer = new int[a.Length];
        for (int i = 0; i < count.Length; i++)
            count[i] = 0;
        for (int i = 0; i < a.Length; i++)
            count[a[i][0]]++;
        for (int i = 0; i < canUse.Length; i++)
            canUse[i] = true;
        while (canUseCount > 0)
        {
            bool isValid = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (canUse[a[i][indexer[i]]]) continue;
                while (!canUse[a[i][indexer[i]]])
                    indexer[i]++;
                count[a[i][indexer[i]]]++;
            }
            for (int i = 0; i < canUse.Length; i++)
            {
                if (!canUse[i])
                    continue;
                if (count[i] <= target)
                    continue;
                canUse[i] = false;
                isValid = false;    
                canUseCount--;
            }
            if (isValid) return true;
        }
        return false;
    }
}
