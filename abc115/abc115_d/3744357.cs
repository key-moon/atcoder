// detail: https://atcoder.jp/contests/abc115/submissions/3744357
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class P
{
    static long[] padCount = new long[51];
    static long[] totalCount = new long[51];
    static void Main()
    {
        padCount[0] = 1;
        totalCount[0] = 1;
        for (int i = 1; i < 51; i++)
        {
            padCount[i] = padCount[i - 1] * 2 + 1;
            totalCount[i] = totalCount[i - 1] * 2 + 3;
        }
        long[] nx = Console.ReadLine().Split().Select(long.Parse).ToArray();

        Console.WriteLine(Solve((int)nx[0], nx[1]));
    }

    static long Solve (int n, long x)
    {
        if (x == 0) return 0;
        if(n == 0) return 1;
        x--;
        if (x == 0) return 0;
        if (x <= totalCount[n - 1]) return Solve(n - 1, x);
        x -= totalCount[n - 1];
        if (x == 0) return padCount[n - 1];
        x--;
        if (x == 0) return padCount[n - 1] + 1;
        if (x <= totalCount[n - 1]) return padCount[n - 1] + 1 + Solve(n - 1, x);
        return padCount[n];
    }

}
