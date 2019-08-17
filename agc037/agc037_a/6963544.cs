// detail: https://atcoder.jp/contests/agc037/submissions/6963544
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
        string last = "";
        string current = "";
        int res = 0;
        int ind = 0;
        while (ind < s.Length)
        {
            current += s[ind++];
            if (last != current)
            {
                last = current;
                current = "";
                res++;
            }
        }
        if (current != "" && last != current) res++;
        Console.WriteLine(res);
    }
}
