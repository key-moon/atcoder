// detail: https://atcoder.jp/contests/code-thanks-festival-2018-open/submissions/4807381
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
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        long res = 0;
        //次の要素をn個生成する通り数
        long[] carryOver = new long[301];
        carryOver[0] = 1;
        for (int i = 0; i < a.Length; i++)
        {
            //0個のキャリーオーバーに1つ書き足すか、1個のキャリーオーバーで終わる
            res = (res + Min(a[i], carryOver[0]) + carryOver[1]) % 1000000007;

            long[] newCarryOver = new long[301];
            for (int j = 0; j <= a[i]; j++)
            {
                for (int k = j % 2; k < carryOver.Length; k += 2)
                {
                    newCarryOver[(j + k) / 2] = (newCarryOver[(j + k) / 2] + carryOver[k]) % 1000000007;
                }
            }
            carryOver = newCarryOver;
        }
        for (int i = 1; i < carryOver.Length; i *= 2) res = (res + carryOver[i]) % 1000000007;
        Console.WriteLine(res);
    }
}
