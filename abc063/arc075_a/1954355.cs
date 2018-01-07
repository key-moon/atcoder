// detail: https://atcoder.jp/contests/abc063/submissions/1954355
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] mod10min = Enumerable.Repeat(int.MaxValue,10).ToArray();
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(Console.ReadLine());
            mod10min[a % 10] = Math.Min(mod10min[a % 10],a);
            sum += a;
        }
        int ind = 0;
        if (sum % 10 == 0) sum -= mod10min.Min(x => (x % 10 != 0 ? x : 100));
        Console.WriteLine(sum % 10 != 0 ? sum : 0);
    }
}
