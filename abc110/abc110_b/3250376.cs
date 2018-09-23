// detail: https://atcoder.jp/contests/abc110/submissions/3250376
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nmxy = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int x = Console.ReadLine().Split().Select(int.Parse).ToArray().Max();
        int y = Console.ReadLine().Split().Select(int.Parse).ToArray().Min();
        for (int i = -1000; i < 1000; i++)
        {
            if (nmxy[2] < i && i <= nmxy[3] && x < i && i <= y)
            {
                Console.WriteLine("No War");
                return;
            }
        }
        Console.WriteLine("War");
    }
}
