// detail: https://atcoder.jp/contests/abc141/submissions/7518086
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
        string s = Console.ReadLine();
        var arr = new string[] { "Sunny", "Cloudy", "Rainy" };
        Console.WriteLine(arr.Concat(arr).SkipWhile(x => x != s).Skip(1).First());
    }
}
