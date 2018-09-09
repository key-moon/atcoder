// detail: https://atcoder.jp/contests/abc057/submissions/3171239
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
        var n = long.Parse(Console.ReadLine());
        for (int i = (int)Ceiling(Sqrt(n)); i >= 0; i--)
        {
            if(n % i == 0)
            {
                Console.WriteLine(Max((n / i).ToString().Length, (i).ToString().Length));
                return;
            }
        }
    }
}
