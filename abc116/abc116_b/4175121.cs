// detail: https://atcoder.jp/contests/abc116/submissions/4175121
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<int> set = new HashSet<int>();
        for (int i = 1;; i++)
        {
            if(!set.Add(n))
            {
                Console.WriteLine(i);
                return;
            }
            n = n % 2 == 0 ? n / 2 : n * 3 + 1;
        }
    }
}
