// detail: https://atcoder.jp/contests/abc138/submissions/6999025
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int[][] nextInds = Enumerable.Repeat(0, s.Length).Select(_ => Enumerable.Repeat(-1, 26).ToArray()).ToArray();
        for (int i = 0; i < 26; i++)
        {
            var targetChar = (char)('a' + i);
            int lastInd = -1;
            for (int j = s.Length - 1; j >= 0; j--)
            {
                nextInds[j][i] = lastInd;
                if (s[j] == targetChar) lastInd = j;
            }
            for (int j = s.Length - 1; j >= 0; j--)
            {
                if (nextInds[j][i] != -1) break;
                nextInds[j][i] = lastInd;
            }
        }
        long sCount = 0;
        int currentInd = s.IndexOf(t[0]);
        if (currentInd == -1)
        {
            Console.WriteLine(-1);
            return;
        }
        foreach (var c in t.Skip(1))
        {
            var nextInd = nextInds[currentInd][c - 'a'];
            if (nextInd == -1)
            {
                Console.WriteLine(-1);
                return;
            }
            if (currentInd >= nextInd) sCount++;
            currentInd = nextInd;
        }
        Console.WriteLine(sCount * s.Length + currentInd + 1);
    }
}
