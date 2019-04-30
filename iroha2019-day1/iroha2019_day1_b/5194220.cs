// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5194220
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++) s = Operate(s);
        Console.WriteLine(s);
    }
    static string Operate(string s) => s.Substring(1) + s[0];
}
