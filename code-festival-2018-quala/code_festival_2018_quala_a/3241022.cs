// detail: https://atcoder.jp/contests/code-festival-2018-quala/submissions/3241022
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
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        int p = s - (a + b + c);
        Console.WriteLine(0 <= p && p <= 3 ? "Yes" : "No");
    }
}
