// detail: https://atcoder.jp/contests/code-festival-2014-qualb/submissions/6389672
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i <= nk[0]; i++)
        {
            nk[1] -= int.Parse(Console.ReadLine());
            if (nk[1] <= 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}
