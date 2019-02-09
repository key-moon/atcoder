// detail: https://atcoder.jp/contests/yahoo-procon2019-qual/submissions/4205534
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] n = new int[10];
        for (int i = 0; i < 3; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            n[ab[0] - 1]++;
            n[ab[1] - 1]++;
        }
        if(n.Max() <= 2)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
