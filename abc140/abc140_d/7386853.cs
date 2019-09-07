// detail: https://atcoder.jp/contests/abc140/submissions/7386853
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        string s = Console.ReadLine();
        Console.WriteLine(Min(s.Zip(s.Skip(1), (x, y) => x == y ? 1 : 0).Sum() + 2 * k, n - 1));
    }
}
