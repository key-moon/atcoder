// detail: https://atcoder.jp/contests/agc017/submissions/6016088
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
        var n = Read();
        var m = Read();
        int[] a = new int[n];
        int[] numCount = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = Read() - 1;
            numCount[a[i]]++;
        }
        long currentChange = 0;
        int[] coveredCount = new int[n];
        for (int i = 0; i < numCount.Length; i++)
        {
            for (int j = 0; j < numCount[i]; j++)
            {
                if (i - j < 0 || 1 <= coveredCount[i - j]++)
                {
                    currentChange++;
                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            var x = Read() - 1;
            var y = Read() - 1;
            numCount[a[x]]--;
            if (a[x] - numCount[a[x]] < 0 || 1 <= --coveredCount[a[x] - numCount[a[x]]])
            {
                currentChange--;
            }
            a[x] = y;
            if (y - numCount[y] < 0 || 1 <= coveredCount[y - numCount[y]]++)
            {
                currentChange++;
            }
            numCount[y]++;
            Console.WriteLine(currentChange);
        }
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
