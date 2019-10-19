// detail: https://atcoder.jp/contests/abc143/submissions/8033430
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var l = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var res = 0;
        for (int i = 1; i < l.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (l[j] * 2 <= l[i]) continue;
                var valid = j;
                var invalid = -1;
                while (valid - invalid > 1)
                {
                    var mid = (valid + invalid) / 2;
                    if (l[i] < l[mid] + l[j]) valid = mid;
                    else invalid = mid;
                }
                res += j - valid;
            }
        }
        Console.WriteLine(res);
    }
}
