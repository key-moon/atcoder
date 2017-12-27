// detail: https://atcoder.jp/contests/abc070/submissions/1914582
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        long[] T = new long[N].Select(x => long.Parse(Console.ReadLine())).ToArray();

        long res = 1;
        List<long> TList = new List<long>();
        for (int i = 0; i < T.Length; i++)
        {
            if (!TList.Contains(T[i]))
            {
                TList.Add(T[i]);
            }
        }
        TList.ForEach(x => res = Lcm(x, res));
        Console.WriteLine(res);
    }

    public static long Lcm(long a, long b)
    {
        return a * (b / Gcd(a, b));
    }
    public static long Gcd(long a, long b)
    {
        if (a < b) return Gcd(b, a);
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
}
