// detail: https://atcoder.jp/contests/diverta2019-2/submissions/5917549
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(nk[1] == 1 ? 0 : nk[0] - nk[1]);
    }
}
