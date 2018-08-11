// detail: https://atcoder.jp/contests/abc105/submissions/2989533
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] l = new int[65536 * 2];
        for (int i = 0; i < l.Length; i++)
        {
            int[] a = Convert.ToString(i, 2).Reverse().Select(x => x == '1' ? 1 : 0).ToArray();
            int current = 1;
            int resasd = 0;
            for (int j = 0; j < a.Length; j++)
            {
                resasd += current * a[j];
                current <<= 1;
                current *= -1;
            }
            l[i] = resasd;
        }
        long res = 0;
        while (true)
        {
            int[] a = Convert.ToString(res, 2).Reverse().Select(x => x == '1' ? 1 : 0).ToArray();
            long current = 1;
            long resasd = 0;
            for (int j = 0; j < a.Length; j++)
            {
                resasd += current * a[j];
                current <<= 1;
                current *= -1;
            }
            if (resasd - 43690 <= n && n <= resasd + 87381)
            {
                long target = n - resasd;
                for (int i = 0; i < l.Length; i++)
                {
                    if(l[i] == target)
                    {
                        Console.WriteLine(string.Join("", Convert.ToString(res + i, 2).Select(x => x == '1' ? 1 : 0)));
                        return;
                    }
                }
                int[] mle = new int[int.MaxValue];
            }
            res += 65536 * 2;
        }
        //Console.WriteLine(string.Join(",", l));
    }
}
