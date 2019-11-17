// detail: https://atcoder.jp/contests/abc145/submissions/8495430
using System;
using System.IO;
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
        var k = Console.ReadLine().Split().Select(int.Parse).Last();
        var heights = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var heightsList = heights.Concat(Enumerable.Repeat(0, 1)).Distinct().OrderBy(x => x).ToArray();
        var heightsDic = heightsList.Select((Elem, Count) => new { Elem, Count }).ToDictionary(x => x.Elem, x => x.Count);

        //dp[今残ってる変えれる回数][今の連鎖してる高さ] := 回数

        var sloped = Enumerable.Repeat(0, k + 1).Select(_ => Enumerable.Repeat(1L << 60, heightsDic.Count).ToArray()).ToArray();
        var flat = Enumerable.Repeat(0, k + 1).Select(_ => Enumerable.Repeat(1L << 60, heightsDic.Count).ToArray()).ToArray();
        sloped[0][0] = 0;
        flat[0][0] = 0;
        var accumedSloped = sloped.Select(_ => new long[heightsDic.Count]).ToArray();
        var accumedDP = flat.Select(_ => new long[heightsDic.Count]).ToArray();
        for (int i = 0; i < sloped.Length; i++)
            MakeFrontAccumlateTable(accumedSloped[i], sloped[i]);
        for (int i = 0; i < flat.Length; i++)
            MakeBackAccumlateTable(accumedDP[i], flat[i]);
        foreach (var height in heights)
        {
            for (int i = 0; i < sloped.Length; i++)
                for (int j = 0; j < sloped[i].Length; j++)
                    sloped[i][j] = 1L << 60;
            for (int i = 0; i < flat.Length; i++)
                for (int j = 0; j < flat[i].Length; j++)
                    flat[i][j] = 1L << 60;

            var heightInd = heightsDic[height];
            
            for (int nextCount = 0; nextCount <= k; nextCount++)
            {
                var val = Min(accumedSloped[nextCount][heightInd] + height, accumedDP[nextCount][heightInd]);
                sloped[nextCount][heightInd] = val - height;
                flat[nextCount][heightInd] = val;
            }

            for (int nextCount = 1; nextCount <= k; nextCount++)
                for (int nextHeightInd = 0; nextHeightInd < heightsDic.Count; nextHeightInd++)
                {
                    var val = Min(accumedSloped[nextCount - 1][nextHeightInd] + heightsList[nextHeightInd], accumedDP[nextCount - 1][nextHeightInd]);
                    if (val - heightsList[nextHeightInd] < sloped[nextCount][nextHeightInd])
                        sloped[nextCount][nextHeightInd] = val - heightsList[nextHeightInd];
                    if (val < flat[nextCount][nextHeightInd])
                        flat[nextCount][nextHeightInd] = val;
                }

            for (int i = 0; i < sloped.Length; i++)
                MakeFrontAccumlateTable(accumedSloped[i], sloped[i]);                
            for (int i = 0; i < flat.Length; i++)
                MakeBackAccumlateTable(accumedDP[i], flat[i]);
        }
        Console.WriteLine(accumedDP.Min(x => x.Min()));
    }

    static void MakeFrontAccumlateTable(long[] target, long[] hoge)
    {
        target[0] = hoge[0];
        for (int i = 1; i < target.Length; i++)
            target[i] = Min(target[i - 1], hoge[i]);
    }
    static void MakeBackAccumlateTable(long[] target, long[] hoge)
    {
        target[target.Length - 1] = hoge[hoge.Length - 1];
        for (int i = target.Length - 2; i >= 0; i--)
            target[i] = Min(target[i + 1], hoge[i]);
    }
}
