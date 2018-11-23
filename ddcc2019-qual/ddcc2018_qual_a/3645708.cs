// detail: https://atcoder.jp/contests/ddcc2019-qual/submissions/3645708
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
        int res = 1;
        for (int i = 0; i < n; i++)
        {
            res *= 4;
        }
        Console.WriteLine(res);
    }
}
