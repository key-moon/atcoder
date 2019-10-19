// detail: https://atcoder.jp/contests/abc143/submissions/8029173
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        Console.WriteLine(s.Length - s.Zip(s.Skip(1), (x, y) => x == y ? 1 : 0).Sum());
    }
}
