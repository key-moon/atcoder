// detail: https://atcoder.jp/contests/agc034/submissions/5751829
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nabcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nabcd[0];
        var a = nabcd[1];
        var b = nabcd[2];
        var c = nabcd[3];
        var d = nabcd[4];
        string s = Console.ReadLine();
        //確実に踏まなければいけない場所
        //abcd
        //acbd
        if (a < b && b < c && c < d || a < c && c < b && b < d)
        {
            if (!s.Substring(a - 1, c - a + 1).Contains("##") && !s.Substring(b - 1, d - b + 1).Contains("##"))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        //abdc
        else if (a < b && b < d && d < c)
        {
            if (!s.Substring(a - 1, c - a + 1).Contains("##") && !s.Substring(b - 1, d - b + 1).Contains("##") && s.Substring(b - 2, (d + 2) - b + 1).Contains("..."))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        else
        {
            throw new Exception();
        }
    }
}
