// detail: https://atcoder.jp/contests/agc024/submissions/2535229
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
        int[] p = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();

        int[] index = new int[p.Length];
        for (int i = 0; i < p.Length; i++)
        {
            index[p[i] - 1] = i;
        }
        //ある中心から順々に下ってる場合は嬉しい
        //中心の数字を決めます
        //中心の数字から上が全て順、または下が全て順であれば、逆側をもう一度やり直すだけ
        //それより上が順だったら?一番上を中心にすればいいだけ
        //昇順の最大まで求める

        //前より後ろよりを組み合わせると効率的にできる?
        //真ん中の方の連続列でもOK 連続列ならね
        //LIS(only +1)
        int count = 1;
        int max = 0;
        for (int i = 1; i < index.Length; i++)
        {
            if (index[i - 1] > index[i])
            {
                max = Max(max, count);
                count = 0;
            }
            count++;
        }
        max = Max(max, count);
        Console.WriteLine(n - max);
    }
}
