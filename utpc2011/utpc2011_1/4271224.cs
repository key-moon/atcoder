// detail: https://atcoder.jp/contests/utpc2011/submissions/4271224
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
        Console.WriteLine(Enumerable.Repeat(0, int.Parse(Console.ReadLine().Split().First())).Max(_ => Console.ReadLine().Count(x => x == '1')));
    }
}
