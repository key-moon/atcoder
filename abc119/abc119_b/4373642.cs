// detail: https://atcoder.jp/contests/abc119/submissions/4373642
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


class P
{
    static void Main()
    {
        float res = 0;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine().Split();
            res += float.Parse(s[0]) * (s[1] == "BTC" ? 380000 : 1);
        }
        Console.WriteLine(res);
    }
}
