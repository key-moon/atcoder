// detail: https://atcoder.jp/contests/joi2008ho/submissions/6661929
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int max = 0;
        int[] chain = new int[s.Length + 1];
        for (int i = 0; i < t.Length; i++)
        {
            for (int j = s.Length - 1; j >= 0; j--)
            {
                max = Max(max, chain[j + 1]);
                chain[j + 1] = 0;
                if (t[i] == s[j])
                    chain[j + 1] = chain[j] + 1;
            }
        }
        Console.WriteLine(Max(max, chain.Max()));
    }
}
