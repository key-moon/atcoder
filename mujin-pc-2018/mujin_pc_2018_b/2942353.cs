// detail: https://atcoder.jp/contests/mujin-pc-2018/submissions/2942353
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool b = n == 0;
        foreach (var c in Console.ReadLine())
        {
            n += c == '+' ? 1 : -1;
            if (n == 0) b = true;
        }
        Console.WriteLine(b ? "Yes" : "No");
    }
}
