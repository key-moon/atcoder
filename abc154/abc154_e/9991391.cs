// detail: https://atcoder.jp/contests/abc154/submissions/9991391
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
public static class P
{
    public static void Main()
    {
        var res = 0;
        var n = Console.ReadLine();
        var k = int.Parse(Console.ReadLine());
        var count = new int[k + 1];
        //count[0] = 1;
        for (int i = 0; i < n.Length; i++)
        {
            var newCount = count.ToArray();
            //今ギリギリでなくなったものを足す
            var nonZeroCount = n.Take(i).Count(x => x != '0');
            if (n[i] != '0' && nonZeroCount <= k) newCount[nonZeroCount]++;
            if (n[i] != '0' && nonZeroCount + 1 <= k) newCount[nonZeroCount + 1] += n[i] - '0' - 1;
            for (int j = 0; j < k; j++)
                newCount[j + 1] += count[j] * 9;
            count = newCount;
        }
        if (n.Count(x => x != '0') == k) count[k]++;
        Console.WriteLine(count[k]);
    }
}
