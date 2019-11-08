// detail: https://atcoder.jp/contests/abc004/submissions/8330548
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
        var rgb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rgb[0];
        var g = rgb[1];
        var b = rgb[2];
        var min = int.MaxValue;
        for (int rRight = -250; rRight <= 150; rRight++)
        {
            var rCost = CalcCost(rRight - r + 1, rRight, -100);
            for (int bLeft = -150; bLeft <= 250; bLeft++)
            {
                var bCost = CalcCost(bLeft, bLeft + b - 1, 100);
                int left = rRight + 1;
                int right = bLeft - 1;
                var middleCount = CalcCount(left, right);
                if (middleCount < g) continue;
                while (g < CalcCount(left, right))
                {
                    if (Abs(left) < Abs(right)) right -= Sign(right);
                    else left -= Sign(left);
                }
                var gCost = CalcCost(left, right, 0);
                var totalCost = rCost + gCost + bCost;
                if (totalCost == 88480)
                {
                        
                }
                min = Min(min, totalCost);
            }
        }
        Console.WriteLine(min);
    }
    public static int CalcCount(int left, int right) => right - left + 1;
    public static int CalcCost(int left, int right, int middle)
    {
        if (left <= middle && middle <= right)
            return Sum(middle - left) + Sum(right - middle);

        if (middle <= left && middle <= right)
            return Sum(right - middle) - Sum(left - middle - 1);

        if (left <= middle && right <= middle)
            return Sum(middle - left) - Sum(middle - right - 1);

        throw new Exception();
    }
    public static int Sum(int until)
    {
        if (until < 0) throw new Exception();
        return until * (until + 1) / 2;
    }
}
