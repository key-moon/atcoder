// detail: https://atcoder.jp/contests/abc114/submissions/3702106
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
        string s = Console.ReadLine();
        int min = int.MaxValue;
        for (int i = 0; i <= s.Length - 3; i++)
        {
            min = Min(min, Abs(753 - int.Parse(s.Substring(i, 3))));
        }
        Console.WriteLine(min);
    }
}
