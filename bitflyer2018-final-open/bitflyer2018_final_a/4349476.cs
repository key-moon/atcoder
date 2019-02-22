// detail: https://atcoder.jp/contests/bitflyer2018-final-open/submissions/4349476
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
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).Min(x => x.Reverse().TakeWhile(y => y == '0').Count()));
    }
}
