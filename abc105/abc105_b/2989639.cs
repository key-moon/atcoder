// detail: https://atcoder.jp/contests/abc105/submissions/2989639
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if(i * 4 + j * 7 == n)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
        }
        Console.WriteLine("No");
    }
}
