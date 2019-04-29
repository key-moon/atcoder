// detail: https://atcoder.jp/contests/abc110/submissions/5181555
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
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        Console.WriteLine(Validate(s, t) && Validate(t, s) ? "Yes" : "No");
    }
    static bool Validate(string s, string t) => s.Zip(t, (x, y) => new Tuple<char, char>(x, y)).Distinct().GroupBy(x => x.Item1).All(x => x.Count() == 1);
}
