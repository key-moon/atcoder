// detail: https://atcoder.jp/contests/code-festival-2018-quala/submissions/3242516
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
        int[] nmab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[] b = new bool[nmab[0]];
        for (int i = 0; i < nmab[1]; i++)
        {
            int[] lr = Console.ReadLine().Split().Select( x =>int.Parse(x) - 1).ToArray();
            for (int j = lr[0]; j <= lr[1]; j++)
            {
                b[j] = true;
            }
        }
        Console.WriteLine(nmab[0] * nmab[2] + Max(0, nmab[3] - nmab[2]) * (nmab[0] - b.Count(x => x)));
    }
}
