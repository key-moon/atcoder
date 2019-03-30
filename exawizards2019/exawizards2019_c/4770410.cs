// detail: https://atcoder.jp/contests/exawizards2019/submissions/4770410
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        //「そのターンのときにそこにいた人は確実に死ぬ」を伝播させていきたい

        //最終ターンからいくらか経った後に
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[] s = Console.ReadLine().ToArray();
        string[] q = Enumerable.Repeat(0, nq[1]).Select(_ => Console.ReadLine()).ToArray();
        int deadLower = -1;
        int deadUpper = nq[0];
        //死ぬ場所の上限下限をもつ
        for (int i = q.Length - 1; i >= 0; i--)
        {
            var query = q[i];
            if (query[2] == 'L')
            {
                if (deadLower + 1 < s.Length && s[deadLower + 1] == query[0]) deadLower++;
                //今そこいても死なないよ!っていうところを作る
                if (0 <= deadUpper && deadUpper < s.Length && s[deadUpper] == query[0]) deadUpper++;
            }
            else
            {
                if (0 <= deadUpper - 1 && s[deadUpper - 1] == query[0]) deadUpper--;
                //そこは安全になったよーってね
                if (0 <= deadLower && deadLower < s.Length && s[deadLower] == query[0]) deadLower--;
            }
        }
        Console.WriteLine(Max(0, deadUpper - deadLower - 1));
    }
}
