// detail: https://atcoder.jp/contests/agc033/submissions/5261792
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
    static int n;
    static string s;
    static string t;
    static void Main()
    {
        var hwn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        n = hwn[2];
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //どっちにも耐えられる状況
        //チェックメイトになる部分
        s = Console.ReadLine();
        t = Console.ReadLine();
        Console.WriteLine(Solve(hwn[0], rc[0] - 1, 'U', 'D') && Solve(hwn[1], rc[1] - 1, 'L', 'R') ? "YES" : "NO");
    }
    static bool Solve(int width, int point, char l, char r)
    {
        //0←L, R→n
        int deadL = -1;
        int deadR = width;
        for (int i = n - 1; i >= 0; i--)
        {
            //逆から見ているので、青木くんの巻き返し
            if (t[i] == l) deadR = Min(width, deadR + 1);
            if (t[i] == r) deadL = Max(-1, deadL - 1);
            if (s[i] == l) deadL = deadL + 1;
            if (s[i] == r) deadR = deadR - 1;
            if (deadL + 1 >= deadR) return false;
        }
        if (deadL < point && point < deadR) return true;
        else return false;
    }
}
