// detail: https://atcoder.jp/contests/abc059/submissions/2180294
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string a = Console.ReadLine().PadLeft(110,'0');
        string b = Console.ReadLine().PadLeft(110, '0');
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < b[i])
            {
                Console.WriteLine("LESS");
                return;
            }
            else if(a[i] > b[i])
            {
                Console.WriteLine("GREATER");
                return;
            }
        }
        Console.WriteLine("EQUAL");
    }
}
