// detail: https://atcoder.jp/contests/abc054/submissions/2452999
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
class P
{
    static void Main()
    {
        int[] ab = Console.ReadLine().Split().Select(x => (int.Parse(x) + 11) % 13).ToArray();
        string res = "";
        if (ab[0] > ab[1]) res = "Alice";
        if (ab[0] < ab[1]) res = "Bob";
        if (ab[0] == ab[1]) res = "Draw";
        Console.WriteLine(res);
    } 
}
