// detail: https://atcoder.jp/contests/yahoo-procon2019-qual/submissions/4204324
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
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();  
        if(((nk[0] + 1) / 2) >= nk[1])
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
