// detail: https://atcoder.jp/contests/abc147/submissions/8852058
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
        string s = Console.ReadLine();
        Console.WriteLine(s.Zip(s.Reverse(), (x, y) => x == y).Sum(x => x ? 0 : 1) / 2);
    }
}
