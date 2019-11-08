// detail: https://atcoder.jp/contests/abc029/submissions/8338321
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        long freeOneCount = 0;
        long bindOneCount = 0;
        long freeCount = 0;
        long bindCount = 1;
        foreach (var c in n.ToString())
        {
            //元からフリーだった奴 0-9で10倍される
            freeOneCount *= 10;
            //1を追加したときに+1される
            freeOneCount += freeCount;
            freeCount *= 10;
            //新しくフリーにする奴
            freeOneCount += bindOneCount * (c - '0') + (c == '0' || c == '1' ? 0 : 1);
            freeCount += bindCount * (c - '0');
            //フリー増量
            if (c == '1') bindOneCount++;
        }
        Console.WriteLine(freeOneCount + bindOneCount);
    }
}
 
