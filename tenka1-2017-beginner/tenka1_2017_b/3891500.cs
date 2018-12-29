// detail: https://atcoder.jp/contests/tenka1-2017-beginner/submissions/3891500
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
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x.First()).Last().Sum());
    }
}
