// detail: https://atcoder.jp/contests/agc027/submissions/8134377
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var X = Console.ReadLine().Split().Select(int.Parse).Last();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).TakeWhile(x => 0 <= (X -= x)).Count() - (0 < X ? 1 : 0));
    }
}
