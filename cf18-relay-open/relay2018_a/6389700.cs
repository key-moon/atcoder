// detail: https://atcoder.jp/contests/cf18-relay-open/submissions/6389700
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
        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            { "Fri", "Sat" },
            { "Sat", "Sun" },
            { "Sun", "Mon" },
            { "Mon", "Tue" },
            { "Tue", "Wed" },
            { "Wed", "Thu" },
            { "Thu", "Fri" },
        };
        Console.WriteLine(string.Join("
", Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => dic[Console.ReadLine()]).ToArray()));
    }
}
