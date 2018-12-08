// detail: https://atcoder.jp/contests/abc115/submissions/3738695
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
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Christmas " + string.Join(" ", Enumerable.Repeat("Eve", 25 - n)));
    }
}
