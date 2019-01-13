// detail: https://atcoder.jp/contests/keyence2019/submissions/3998306
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        (string.Join("", Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x)) == "1479" ? "YES" : "NO").WriteLine();
    }
}


static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
