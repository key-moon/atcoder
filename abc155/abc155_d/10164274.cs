// detail: https://atcoder.jp/contests/abc155/submissions/10164274
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Reader;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = NextLong;
        var k = NextLong;
        var a = Enumerable.Range(0,  (int)n).Select(_ => NextLong).OrderBy(x => x).ToArray();
        var Valid = -(long)1e18 + 1;
        var Invalid = (long)1e18 + 1;
        //小さい数の個数
        while (Invalid - Valid > 1)
        {
            var target = (Valid + Invalid) / 2;
            var res = 0L;
            //res = Enumerable.Range(0, a.Length).Sum(ind => Count(ind, mid));
            for (int ind = 0; ind < a.Length; ind++)
            {
                int valid, invalid;
                //負
                if (a[ind] < 0) { valid = a.Length; invalid = ind; }
                //正
                else{ invalid = a.Length; valid = ind; }

                while (Abs(valid - invalid) > 1)
                {
                    var mid = (valid + invalid) / 2;
                    if (a[ind] * a[mid] <= target) valid = mid;
                    else invalid = mid;
                }
                if (a[ind] < 0) res += a.Length - valid;
                else res += valid - ind;
            }
            if (res < k) Valid = target;
            else Invalid = target;
        }
        Console.WriteLine(Invalid);
    }
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }

    public static long NextLong
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            long res = 0; int sign = 1; while (Buffer[ptr] < 45) Move();
            if (Buffer[ptr] == 45) { Move(); sign = -1; }
            do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res * sign;
        }
    }
}
