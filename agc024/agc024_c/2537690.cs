// detail: https://atcoder.jp/contests/agc024/submissions/2537690
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        //始めは0
        //狭義単調増加列に分解

        //後ろから見ていって、Ni-1がそうあるべきだと考える

        //1 1みたいになったときは再構築しないとダメ
        //a[i-1]+1==a[i]のときはラッキーで+1
        
        //到達不能の検出漏れはない
        //到達可能なのに不能と判定されているかも。-> ない (13WA->13WA)
        //個数のミスだよなあ もうちょっと少なく出来る又は多い必要がある
        long res = 0;
        for (int i = a.Length - 1; i >= 1; i--)
        {
            if (a[i] - a[i - 1] > 1)
            {
                res = -1;
                goto end;
            }

            if (a[i - 1] + 1 == a[i]) res++;
            else res += a[i];
        }
        end:;
        if (a[0] != 0) res = -1;
        Console.WriteLine(res);
    }
}
