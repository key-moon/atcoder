// detail: https://atcoder.jp/contests/keyence2019/submissions/3999560
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
        string s = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < s.Length - i; j++)
            {
                if("keyence" == s.Substring(0, i) + s.Substring(i + j))
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
        }
        Console.WriteLine("NO");
    }
}


static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
