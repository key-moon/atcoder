// detail: https://atcoder.jp/contests/k2pc-easy/submissions/4920255
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var n = GetElem(nm[0]);
        var m = GetElem(nm[1]);

        Console.WriteLine(GetInd(n.Item1 + m.Item1, n.Item2 + m.Item2));
    }
    static Tuple<int,int> GetElem(int index)
    {
        long sqrt = (int)Floor(Sqrt((index - 1) * 2));
        while (index > sqrt * (sqrt + 1) / 2) sqrt++;
        var curRowLastInd = sqrt * (sqrt + 1) / 2;
        var first = curRowLastInd - index + 1;
        var second =  (sqrt + 1) - first;
        return new Tuple<int, int>((int)first, (int)second);
    }
    static long GetInd(long a, long b)
    {
        long sqrt = (a + b - 1);
        var curRowLastInd = sqrt * (sqrt + 1) / 2;
        var Ind = curRowLastInd - a + 1;
        return Ind;
    }
}
