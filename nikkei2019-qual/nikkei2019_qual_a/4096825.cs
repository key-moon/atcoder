// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/4096825
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
        int[] nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine($"{Min(nab[1], nab[2])} {Max(0, (nab[1] + nab[2]) - nab[0])}");
    }
}
