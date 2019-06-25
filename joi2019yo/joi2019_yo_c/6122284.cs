// detail: https://atcoder.jp/contests/joi2019yo/submissions/6122284
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(Regex.Matches(Console.ReadLine(), "((OX)|(XO))").Count);
    }
}
