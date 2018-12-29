// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/3891428
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int total = 0;
        int inter = 0;
        string s = Console.ReadLine();
        foreach (var c in s)
        {
            bool b = false;
            if(c == 'a')
            {
                if(total < nab[1] + nab[2])
                {
                    b = true;
                }
            }
            if(c == 'b')
            {
                if(total < nab[1] + nab[2] && inter < nab[2])
                {
                    b = true;
                    inter++;
                }
            }
            if (b)
            {
                total++;
                Console.WriteLine("Yes");

            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
