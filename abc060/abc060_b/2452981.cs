// detail: https://atcoder.jp/contests/abc060/submissions/2452981
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
class P
{
    static void Main()
    {
        int[] abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i <= abc[1]; i++)
        {
            if((abc[0] * i) % abc[1] == abc[2])
            {
                Console.WriteLine("YES");
                return;
            } 
        }
        Console.WriteLine("NO");
    }
}
