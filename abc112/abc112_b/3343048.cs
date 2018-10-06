// detail: https://atcoder.jp/contests/abc112/submissions/3343048
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res;
        try
        {

            res = Enumerable.Repeat(0, nt[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Where(x => x[1] <= nt[1]).Min(x => x[0]);
        Console.WriteLine(res);
        }
        catch
        {
            Console.WriteLine("TLE");
            
        }
    }
}
