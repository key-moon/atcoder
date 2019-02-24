// detail: https://atcoder.jp/contests/abc119/submissions/4375002
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;


class P
{
    static void Main()
    {
        var abq = Console.ReadLine().Split().Select(int.Parse).ToList();
        var s = Enumerable.Repeat(0, abq[0]).Select(_ => long.Parse(Console.ReadLine())).ToList();
        var t = Enumerable.Repeat(0, abq[1]).Select(_ => long.Parse(Console.ReadLine())).ToList();
        var x = Enumerable.Repeat(0, abq[2]).Select(_ => long.Parse(Console.ReadLine())).ToList();
        foreach (var place in x)
        {
            var sres = s.BinarySearch(place);
            long sbefdst = 0;
            long saftdst = 0;
            if (sres <= 0)
            {
                sres = ~sres;
                if (sres != 0) sbefdst = place - s[sres - 1];
                else sbefdst = long.MaxValue / 4;
                if (sres < s.Count) saftdst = s[sres] - place;
                else saftdst = long.MaxValue / 4;
            }
            var tres = t.BinarySearch(place);
            long tbefdst = 0;
            long taftdst = 0;
            if (tres <= 0)
            {
                tres = ~tres;
                if (tres != 0) tbefdst = place - t[tres - 1];
                else tbefdst = long.MaxValue / 4;
                if (tres < t.Count) taftdst = t[tres] - place;
                else taftdst = long.MaxValue / 4;
            }
            var res = Min(Max(sbefdst, tbefdst), Max(saftdst, taftdst));
            res = Min(res, Min(sbefdst + taftdst + Min(sbefdst, taftdst), tbefdst + saftdst + Min(tbefdst, saftdst)));
            Console.WriteLine(res);
        }
    }
}
