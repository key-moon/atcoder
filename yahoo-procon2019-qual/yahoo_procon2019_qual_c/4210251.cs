// detail: https://atcoder.jp/contests/yahoo-procon2019-qual/submissions/4210251
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
        int[] kab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //+++tt
        //+++++
        //++/++
        kab[0]++;
        int cycle = 1;
        long incr = 1; 
        if (kab[2] -  kab[1] >= 2)
        {
            if(kab[0] <= kab[1])
            {
                Console.WriteLine(kab[0]);
            }
            kab[0] -= kab[1];
            Console.WriteLine(kab[1] + (long)(kab[2] - kab[1]) * ((long)kab[0] / 2) + kab[0] % 2);
            
        }
        else
        {
            Console.WriteLine(kab[0]);
        }
    }
}
