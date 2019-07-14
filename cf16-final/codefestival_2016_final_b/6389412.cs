// detail: https://atcoder.jp/contests/cf16-final/submissions/6389412
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        int i = 0;
        for (; sum <= n; i++, sum += i) ;
        Console.WriteLine(string.Join("
", Enumerable.Range(1, i).Where(x => x != sum - n)));
    }
}
