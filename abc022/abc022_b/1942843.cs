// detail: https://atcoder.jp/contests/abc022/submissions/1942843
using System;
using System.Linq;
using System.Collections.Generic;
 
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] v = new int[100010];
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            v[int.Parse(Console.ReadLine())]++;
        }
        foreach (var i in v)
        {
            if (i > 1) res += i - 1;
        }
        Console.WriteLine(res);
    }
}
