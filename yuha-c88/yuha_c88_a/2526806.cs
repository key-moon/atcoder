// detail: https://atcoder.jp/contests/yuha-c88/submissions/2526806
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("", Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split()).Select(x => (x[0] == "BEGINNING" ? x[2].First() : (x[0] == "END" ? x[2].Last() : x[2][x[2].Length / 2])))));
    }
}
