// detail: https://atcoder.jp/contests/abc117/submissions/4154640
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] tx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((double)tx[0] / (double)tx[1]);
    }
}
