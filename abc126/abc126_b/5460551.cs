// detail: https://atcoder.jp/contests/abc126/submissions/5460551
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
        string s = Console.ReadLine();
        int fir = int.Parse(s.Substring(0, 2));
        int sec = int.Parse(s.Substring(2, 2));
        if (isMonth(fir) && isMonth(sec)) Console.WriteLine("AMBIGUOUS");
        if (isMonth(fir) && !isMonth(sec)) Console.WriteLine("MMYY");
        if (!isMonth(fir) && isMonth(sec)) Console.WriteLine("YYMM");
        if (!isMonth(fir) && !isMonth(sec)) Console.WriteLine("NA");
    }
    static bool isMonth(int n) => 1 <= n && n <= 12;
}
