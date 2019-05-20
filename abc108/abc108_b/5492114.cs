// detail: https://atcoder.jp/contests/abc108/submissions/5492114
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var xyxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x1 = xyxy[0];
        var y1 = xyxy[1];
        var x2 = xyxy[2];
        var y2 = xyxy[3];
        int dirx = x2 - x1;
        int diry = y2 - y1;
        Console.WriteLine($"{x2 - diry} {y2 + dirx} {x2 - dirx - diry} {y2 + dirx - diry}");
    }
}
