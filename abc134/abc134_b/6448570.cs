// detail: https://atcoder.jp/contests/abc134/submissions/6448570
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sec = nd[1] + 1 + nd[1];
        Console.WriteLine((nd[0] + sec - 1) / sec);
    }
}
