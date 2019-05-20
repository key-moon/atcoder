// detail: https://atcoder.jp/contests/joi2006yo/submissions/5495283
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
        int top = 1;
        int u = 5;
        int d = 2;
        int l = 4;
        int r = 3;
        int bottom = 6;
        int n = int.Parse(Console.ReadLine());
        int res = 1;
        for (int i = 0; i < n; i++)
        {
            switch (Console.ReadLine())
            {
                case "Left":
                    Rotate(ref u, ref r, ref d, ref l);
                    break;
                case "Right":
                    Rotate(ref u, ref l, ref d, ref r);
                    break;
                case "North":
                    Rotate(ref top, ref d, ref bottom, ref u);
                    break;
                case "South":
                    Rotate(ref top, ref u, ref bottom, ref d);
                    break;
                case "East":
                    Rotate(ref top, ref l, ref bottom, ref r);
                    break;
                case "West":
                    Rotate(ref top, ref r, ref bottom, ref l);
                    break;
            }
            res += top;
        }
        Console.WriteLine(res);
    }
    static void Rotate(ref int a, ref int b, ref int c, ref int d)
    {
        var tmp = a;
        a = b;
        b = c;
        c = d;
        d = tmp;
    }
}
