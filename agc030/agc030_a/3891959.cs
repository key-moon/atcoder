// detail: https://atcoder.jp/contests/agc030/submissions/3891959
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        long[] abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(Min(abc[0] + abc[1] + 1, abc[2]) + abc[1]);
    }
}
