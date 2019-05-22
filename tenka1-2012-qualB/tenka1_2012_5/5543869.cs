// detail: https://atcoder.jp/contests/tenka1-2012-qualB/submissions/5543869
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i <= 127; i++)
        {
            if (i % 3 == abc[0] && i % 5 == abc[1] && i % 7 == abc[2])
                Console.WriteLine(i);
        }
    }
}
