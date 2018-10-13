// detail: https://atcoder.jp/contests/agc028/submissions/3392840
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        string t = Console.ReadLine();

        long lcm = Lcm(nm[0], nm[1]);
        Dictionary<long, char> dict = new Dictionary<long, char>();
        long len = lcm / t.Length;
        for (int i = 0; i < t.Length; i++)
        {
            dict.Add(len * i, t[i]);
        }

        len = lcm / s.Length;
        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(len * i))
            {
                if(dict[len * i] != s[i])
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
        Console.WriteLine(lcm);
    }

    static long Lcm(long a, long b)
    {
        return a * b / Gcd(a, b);
    }

    static long Gcd(long a, long b)
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
