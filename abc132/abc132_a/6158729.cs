// detail: https://atcoder.jp/contests/abc132/submissions/6158729
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(s.GroupBy(x => x).All(x => x.Count() == 2) ? "Yes" : "No");
    }
}
