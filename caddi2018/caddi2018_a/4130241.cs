// detail: https://atcoder.jp/contests/caddi2018/submissions/4130241
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        long[] np = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(factors(np[1]).GroupBy(x => x).Aggregate(1L, (x, y) => x * Max(1, Power(y.Key, y.Count() / np[0]))));    
    }

    static long Power(long n, long m)
    {
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }
  
    static long[] factors(long n)
    {
        long firstn = n;
        long i = 2;
        List<long> res = new List<long>();
        while (i * i <= firstn + 100)
        {
            while (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
            i++;
        }
        if (n > 1) res.Add(n);
        return res.ToArray();
    }
}
