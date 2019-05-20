// detail: https://atcoder.jp/contests/joi2006yo/submissions/5495156
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
        int n = int.Parse(Console.ReadLine());
        char[] convert = Enumerable.Range(0, 'z' + 1).Select(x => (char)x).ToArray();
        for (int i = 0; i < n; i++)
        {
            string c = Console.ReadLine();
            convert[c[0]] = c[2];
        }
        string res = "";
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++) res += convert[Console.ReadLine()[0]];
        Console.WriteLine(res);
    }
}
