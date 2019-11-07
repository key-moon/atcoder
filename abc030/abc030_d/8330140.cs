// detail: https://atcoder.jp/contests/abc030/submissions/8330140
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
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var na = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = na[0];
        var cur = na[1] - 1;

        var kstr = Console.ReadLine();
        int k;

        int step = 0;
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        int[] stepCount = Enumerable.Repeat(-1, n).ToArray();

        if (kstr.Length <= 5)
        {
            k = int.Parse(kstr);
            while (stepCount[cur] == -1)
            {
                stepCount[cur] = step++;
                k--;
                cur = a[cur];
                if (k == 0)
                {
                    Console.WriteLine(cur + 1);
                    return;
                }
            }
            k %= step - stepCount[cur];
        }
        else
        {
            while (stepCount[cur] == -1)
            {
                stepCount[cur] = step++;
                cur = a[cur];
            }

            int sum = 0;
            int rank = 1;
            int mod = (step - stepCount[cur]);
            foreach (var item in kstr.Reverse())
            {
                sum += (item - '0') * rank;
                rank *= 10;
                sum %= mod;
                rank %= mod;
            }
            k = ((sum + mod - (step % mod)) % mod);
        }
        for (int i = 0; i < k; i++)
        {
            cur = a[cur];
        }
        Console.WriteLine(cur + 1);
    }
}
