// detail: https://atcoder.jp/contests/fuka5/submissions/4969198
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (s == "0") return;
            var year = int.Parse(s.Substring(0, s[5] == '/' ? 5 : 4));
            s = (year % 400 + 400).ToString() + s.Substring(s[5] == '/' ? 5 : 4);
            year = (year / 400) * 400 - 400;
            var time = DateTime.Parse(s).AddSeconds(Convert.ToInt32(Console.ReadLine(), 2));
            Console.WriteLine($"{year + time.Year}/{time.ToString("MM/dd HH:mm:ss")}");
        }
    }
}
