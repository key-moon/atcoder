// detail: https://atcoder.jp/contests/arc036/submissions/8339865
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using System.Runtime.CompilerServices;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var h = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        int[] incrCount = new int[n];
        int[] decrCount = new int[n];
        
        for (int i = 1; i < n; i++)
            incrCount[i] = h[i - 1] < h[i] ? incrCount[i - 1] + 1 : 0;
        for (int i = n - 2; i >= 0; i--)
            decrCount[i] = h[i] > h[i + 1] ? decrCount[i + 1] + 1 : 0;

        Console.WriteLine(incrCount.Zip(decrCount, (x, y) => x + y).Max() + 1);
    }
}
 
