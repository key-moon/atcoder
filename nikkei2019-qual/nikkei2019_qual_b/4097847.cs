// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/4097847
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
        int n = int.Parse(Console.ReadLine());
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res += (new char[] { a[i], b[i], c[i] }).Distinct().Count() - 1;
        }
        Console.WriteLine(res);
    }
}
