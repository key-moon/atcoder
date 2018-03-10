// detail: https://atcoder.jp/contests/abc062/submissions/2180252
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] s = new string[a[0]];
        for (int i = 0; i < a[0]; i++)
        {
            s[i] = Console.ReadLine();
        }
        Console.WriteLine("".PadLeft(a[1] + 2, '#'));
        for (int i = 0; i < a[0]; i++)
        {
            Console.WriteLine($"#{s[i]}#");
        }
        Console.WriteLine("".PadLeft(a[1] + 2, '#'));
    }
}
