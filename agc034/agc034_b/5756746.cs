// detail: https://atcoder.jp/contests/agc034/submissions/5756746
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

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        s = s.Replace("BC", "X");

        Console.WriteLine(Regex.Matches(s, "[AX]*").Cast<Match>().Select(x => getScore(x.Value)).Sum());
    }
    static long getScore(string s)
    {
        long countA = 0;
        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'A') countA++;
            else res += countA;
        }
        return res;
    }
    /*
    static long getScore(string s)
    {
        var a = s.TakeWhile(x => x == 'A').Count() - 1;
        var abc = s.Count(x => x == 'A') - a;
        var bc = s.Count(x => x == 'C') - abc;
        var score = getScore(a, abc, bc);
        Console.WriteLine($"{s} a : {a} abc : {abc} bc : {bc}
score : {score}");
        return score;
    }
    static long getScore(long a, long abc, long bc)
    {
        long res = 0;
        var incr = Min(a, bc);

        res += abc * (incr + 1) + incr * (incr + 1) / 2;

        var stay = Abs(a - bc);
        abc += incr;

        res += stay * abc;

        abc -= 1;

        res += abc * (abc + 1) / 2;

        return res;
    }*/
}
