// detail: https://atcoder.jp/contests/abc060/submissions/2180278
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i <= 1000; i++)
        {
            if((abc[0] * i) % abc[1] == abc[2])goto end;
        }
        Console.WriteLine("NO");
        return;
        end:;
        Console.WriteLine("YES");
    }
}
