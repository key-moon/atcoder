// detail: https://atcoder.jp/contests/abc105/submissions/2989716
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(nk[0] % nk[1] == 0 ? 0 : 1);
    }
}
