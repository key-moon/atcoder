// detail: https://atcoder.jp/contests/code-formula-2014-quala/submissions/6389541
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[] code = Enumerable.Repeat('x', 10).ToArray();
        foreach (var item in Console.ReadLine().Split().Where(x => x.Length != 0).Select(int.Parse))
            code[item] = '.';
        foreach (var item in Console.ReadLine().Split().Where(x => x.Length != 0).Select(int.Parse))
            code[item] = 'o';
        Console.WriteLine(
            $"{code[7]} {code[8]} {code[9]} {code[0]}
" + 
            $" {code[4]} {code[5]} {code[6]}
" + 
            $"  {code[2]} {code[3]}
" + 
            $"   {code[1]}");
    }
}
