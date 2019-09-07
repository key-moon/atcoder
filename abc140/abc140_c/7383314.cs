// detail: https://atcoder.jp/contests/abc140/submissions/7383314
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(b.Zip(b.Skip(1), Min).Sum() + b.First() + b.Last());
    }
}
