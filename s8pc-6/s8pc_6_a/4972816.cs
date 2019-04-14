// detail: https://atcoder.jp/contests/s8pc-6/submissions/4972816
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((int)Ceiling((double)Console.ReadLine().Split().Select(int.Parse).Sum() / nt[1]));
    }
}
