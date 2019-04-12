// detail: https://atcoder.jp/contests/k2pc-easy/submissions/4926027
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var k = int.Parse(Console.ReadLine());
        var covered = Enumerable.Repeat(0, k + 1).Select(_ => new HashSet<long>()).ToArray();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var pq = Console.ReadLine().Split().Select(long.Parse).ToArray();
            covered[pq[0]].Add(pq[1] - 1);
        }

        long res = 0;
        long row = 1;
        for (int i = 0; i < covered.Length; i++)
        {
            int coverCount = 0;
            foreach (var item in covered[i])
            {
                var itemCopy = item;
                for (int j = i - 1; j >= 0; j--)
                {
                    itemCopy /= 2;
                    if (covered[j].Contains(itemCopy)) goto end;
                }
                coverCount++;
                end:;
            }
            row -= coverCount;
            res += row;
            Debug.WriteLine(row);
            row *= 2;
        }
        Console.WriteLine(res);
    }
    
}
