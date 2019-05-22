// detail: https://atcoder.jp/contests/kupc2012/submissions/5543926
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nte = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < nte[0]; i++)
        {
            for (int j = 0; j * x[i] <= nte[1] + nte[2]; j++)
            {
                if (nte[1] - nte[2] <= j * x[i])
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }
        }
        Console.WriteLine(-1);
    }
}
