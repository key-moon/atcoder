// detail: https://atcoder.jp/contests/abc027/submissions/5435109
using System;

static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int turn = 0;
        while (n >= 1L << ++turn) ;
        var idealState = 0x2aaaaaaaaaaaaaaaL & ((1L << turn) - 1) | (1L << (turn - 1));
        if (idealState <= n) turn++;
        Console.WriteLine((turn & 1) == 1 ? "Takahashi" : "Aoki");
    }
}
