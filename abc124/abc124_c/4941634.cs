// detail: https://atcoder.jp/contests/abc124/submissions/4941634
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
        string s = Console.ReadLine();
        Console.WriteLine(Min(
            F(s, Enumerable.Range(0, s.Length).Select(x => x & 1)),
            F(s, Enumerable.Range(1, s.Length).Select(x => x & 1))));
    }
    static int F(string s, IEnumerable<int> l) => s.Zip(l, (x, y) => x - '0' == y ? 0 : 1).Sum();
}
