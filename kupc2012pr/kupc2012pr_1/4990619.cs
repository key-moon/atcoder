// detail: https://atcoder.jp/contests/kupc2012pr/submissions/4990619
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{

    static void Main()
    {
        var mn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        switch (mn[0])
        {
            case 0:
                Console.WriteLine(mn[1] + 1);
                break;
            case 1:
                Console.WriteLine(mn[1] + 2);
                break;
            case 2:
                Console.WriteLine((mn[1] + 3) * 2 - 3);
                break;
            case 3:
                Console.WriteLine((1UL << (mn[1] + 3)) - 3);
                break;
            default:
                break;
        }
    }
}
