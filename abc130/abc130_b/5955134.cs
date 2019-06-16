// detail: https://atcoder.jp/contests/abc130/submissions/5955134
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int place = 0;
        int count = 1;
        for (int i = 0; i < l.Length; i++)
        {
            place += l[i];
            if (x < place)
            {
                Console.WriteLine(count);
                return;
            }
            count++;
        }
        Console.WriteLine(count);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}
