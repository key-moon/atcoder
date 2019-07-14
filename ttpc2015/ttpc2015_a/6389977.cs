// detail: https://atcoder.jp/contests/ttpc2015/submissions/6389977
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
        Console.WriteLine($"{(s[2] == 'B' ? "Bachelor" : s[2] == 'M' ? "Master" : "Doctor")} {s[0]}{s[1]}");
    }
}
