// detail: https://atcoder.jp/contests/abc140/submissions/7381106
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(b.Sum() + a.Zip(a.Skip(1), (x, y) => y - x == 1 ? c[x - 1] : 0).Sum());
    }
}
