// detail: https://atcoder.jp/contests/abc116/submissions/4059420
using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Math;
 

class P
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).Take(2).Aggregate(1, (x, y) => x * y) / 2);
    }
}
