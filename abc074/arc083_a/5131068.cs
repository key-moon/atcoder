// detail: https://atcoder.jp/contests/abc074/submissions/5131068
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        var abcdef = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcdef[0] * 100;
        var b = abcdef[1] * 100;
        var c = abcdef[2];
        var d = abcdef[3];
        var e = abcdef[4];
        var f = abcdef[5];
        List<int> possibleSugarWeights = new List<int>();
        for (int i = 0; c * i <= f; i++)
            for (int j = 0; c * i + d * j <= f; j++)
                possibleSugarWeights.Add(c * i + d * j);
        possibleSugarWeights = possibleSugarWeights.Distinct().OrderBy(x => x).ToList();

        double maxDense = -1;
        Tuple<int, int> maxStatus = new Tuple<int, int>(-1, -1);
        for (int i = 0; a * i <= f; i++)
        {
            for (int j = 0; a * i + b * j <= f; j++)
            {
                var waterWeight = a * i + b * j;
                var maxSugar = Min(f - waterWeight, waterWeight * e / 100);
                var sugarInd = possibleSugarWeights.BinarySearch(maxSugar);
                if (sugarInd < 0) sugarInd = (~sugarInd) - 1;
                if (sugarInd < 0) continue;
                var sugarWeight = possibleSugarWeights[sugarInd];
                var sugarWaterWeight = sugarWeight + waterWeight;
                var dense = (double)sugarWeight / sugarWaterWeight;
                if (dense > maxDense)
                {
                    maxDense = dense;
                    maxStatus = new Tuple<int, int>(sugarWaterWeight, sugarWeight);
                }
            }
        }
        Console.WriteLine($"{maxStatus.Item1}
{maxStatus.Item2}");
    }
}
