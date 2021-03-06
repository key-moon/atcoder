// detail: https://atcoder.jp/contests/agc031/submissions/4669519
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


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //最も近い石を選ぶ、で良い
        //選んだ場合は次の始点
        long score = 1;
        long[] lastCount = new long[200001];
        int lastColor = -1;
        for (int i = 0; i < n; i++)
        {
            var c = int.Parse(Console.ReadLine());
            if (lastColor == c) continue;
            lastColor = c;
            score += lastCount[c];
            score %= 1000000007;
            lastCount[c] = score;
        }
        Console.WriteLine(score);
    }
}
