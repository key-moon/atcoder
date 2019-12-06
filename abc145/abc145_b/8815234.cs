// detail: https://atcoder.jp/contests/abc145/submissions/8815234
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        if (s.Substring(0, n / 2) == s.Substring(n / 2))
        {
            Console.WriteLine("Yes");
            return;
        }
        Console.WriteLine("No");
    }
}
