// detail: https://atcoder.jp/contests/agc019/submissions/5376953
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        long res = 0;
        long[] charCount = new long[26];
        for (int i = 0; i < s.Length; i++) charCount[s[i] - 'a']++;
        for (int i = 1; i < 26; i++)
        {
            res += charCount.Take(i).Sum() * charCount[i];
        }
        Console.WriteLine(res + 1);
    }
}
