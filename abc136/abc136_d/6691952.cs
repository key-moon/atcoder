// detail: https://atcoder.jp/contests/abc136/submissions/6691952
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int[] res = new int[s.Length];
        int i = 0;
        while (true)
        {
            int rCount = 0;
            while (s[i] == 'R')
            {
                rCount++;
                i++;
            }
            res[i - 1] += rCount / 2 + rCount % 2;
            res[i] += rCount / 2;
            int lInd = i;
            int lCount = 0;
            while (i < s.Length && s[i] == 'L')
            {
                lCount++;
                i++;
            }
            res[lInd - 1] += lCount / 2;
            res[lInd] += lCount / 2 + lCount % 2;
            if (i >= s.Length) break;
        }
        Console.WriteLine(string.Join(" ", res));
    }


    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
