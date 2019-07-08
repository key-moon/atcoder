// detail: https://atcoder.jp/contests/abc045/submissions/6312996
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var h = NextInt;
        var w = NextInt;
        var n = NextInt;
        HashSet<Tuple> candidateCenter = new HashSet<Tuple>();
        HashSet<Tuple> black = new HashSet<Tuple>();
        for (int iterate = 0; iterate < n; iterate++)
        {
            var a = NextInt;
            var b = NextInt;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Tuple point = new Tuple(a + i, b + j);
                    if (point.Item1 <= 1 || h - 1 < point.Item1 || point.Item2 <= 1 || w - 1 < point.Item2)
                        continue;
                    candidateCenter.Add(point);
                }
            }
            black.Add(new Tuple(a, b));
        }
        var res = new long[10];
        res[0] = (long)(h - 2) * (w - 2);
        foreach (var cand in candidateCenter.ToArray())
        {
            res[0]--;
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (black.Contains(new Tuple(cand.Item1 + i, cand.Item2 + j)))
                        count++;
                }
            }
            res[count]++;
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

struct Tuple
{
    public int Item1;
    public int Item2;
    public Tuple(int item1, int item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
    public override int GetHashCode() => (Item1 << 2) + (Item2 << 5) + (Item1 ^ Item2);
}
