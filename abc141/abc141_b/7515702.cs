// detail: https://atcoder.jp/contests/abc141/submissions/7515702
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
        var a = s.Where((x, y) => y % 2 == 1).All(x => x == 'L' || x == 'U' || x == 'D');
        var b = s.Where((x, y) => y % 2 == 0).All(x => x == 'R' || x == 'U' || x == 'D');
        Console.WriteLine(a && b ? "Yes" : "No");
    }
}
