// detail: https://atcoder.jp/contests/abc131/submissions/6052388
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
        string s = Console.ReadLine();
        Console.WriteLine(s[0] == s[1] || s[1] == s[2] || s[2] == s[3] ? "Bad": "Good");
    }
}
