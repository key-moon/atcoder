// detail: https://atcoder.jp/contests/abc122/submissions/4700215
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //入れ替えを一度行うことで違反させる
        //AG GC A Cのペアが存在するとダメ
        //含むステートを列挙

        //まずAGCを全て含むパターンを列挙
        long[] states = new long[64];
        states[0] = 1;
        for (int i = 0; i < n; i++)
        {
            long[] newstates = new long[64];
            for (int j = 0; j < newstates.Length; j++)
            {
                var lastTwo = j & 15;
                var lastOne = lastTwo & 3;
                var firstTwo = j >> 2;
                var firstOne = j >> 4;
                //  t,a,g,c←last
                //t 0,1,2,3
                //a 4,5,6,7
                //g 8,9,a,b
                //c c,d,e,f
                //↑
                //second
                for (int k = 0; k < 4; k++)
                {
                    if (lastTwo == 0x6/*ag*/ && k == 3) continue;
                    if (lastTwo == 0x7/*ac*/ && k == 2) continue;
                    if (lastTwo == 0x9/*ga*/ && k == 3) continue;

                    if (firstTwo == 0x6/*ag-*/ && k == 3) continue;
                    if (firstOne == 1 && lastOne == 2/*a-g*/ && k == 3) continue;

                    var newLast = (lastTwo << 2) | (k);
                    newstates[newLast] += states[j];
                    newstates[newLast] %= 1000000007;
                }
            }
            states = newstates;
        }
        var res = states.Sum() % 1000000007;
        Console.WriteLine(res);
    }

    static long Power(long n, long m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return res;
    }
}

enum Base
{
    t = 0,
    a = 1,
    g = 2,
    c = 3
}
