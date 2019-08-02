// detail: https://atcoder.jp/contests/otemae2019/submissions/6648518
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = NextInt;
        var q = NextInt;
        //長さDのチェーンがあって間隔1でたわんで置かれてて、ぐわーって引っ張ってく
        //クエリ先読みしてソートしてから答えておきたいね
        //動いている途中の生徒は一人だけ
        int[] d = new int[n];
        int[] accumLength = new int[n + 1];
        for (int i = 0; i < d.Length; i++)
        {
            d[i] = NextInt;
            accumLength[i + 1] = accumLength[i] + d[i];
        }
        int[] res = new int[q];
        for (int query = 0; query < q; query++)
        {
            int t = NextInt;
            int l = NextInt;
            int r = NextInt;
            //0 l <--> r inf

            int rvalid = -1;
            int rinvalid = accumLength.Length;
            while (rinvalid -rvalid > 1)
            {
                var mid = (rinvalid + rvalid) / 2;
                if (r < -accumLength[mid] + t) rvalid = mid;
                else rinvalid = mid;
            }

            int lvalid = -1;
            int linvalid = accumLength.Length;
            while (linvalid - lvalid > 1)
            {
                var mid = (linvalid + lvalid) / 2;
                if (l <= -accumLength[mid] + t) lvalid = mid;
                else linvalid = mid;
            }

            //[lvalid, rvalid)
            res[query] = lvalid - rvalid;
        }
        Console.WriteLine(string.Join("
", res));
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
