// detail: https://atcoder.jp/contests/tenka1-2015-qualb/submissions/6389883
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        if (s == "{}")
        {
            Console.WriteLine("dict");
            return;
        }
        int depth = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '{') depth++;
            if (s[i] == '}') depth--;
            if (s[i] == ':' && depth == 1)
            {
                Console.WriteLine("dict");
                return;
            }
        }
        Console.WriteLine("set");
    }
}
