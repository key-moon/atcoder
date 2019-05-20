// detail: https://atcoder.jp/contests/nikkei2019-ex/submissions/5493076
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Console.WriteLine((426 >> (int)(long.Parse(Console.ReadLine()) % 9) & 1) == 1 ? "Win" : "Lose");
    }
}
