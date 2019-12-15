// detail: https://atcoder.jp/contests/abc071/submissions/8961304
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        try
        {
        Console.WriteLine((char)Enumerable.Range((int)'a', 26).First(x => !s.Contains((char)x)));
        }
        catch
        {
            Console.WriteLine("None");
        }
    }
}
