// detail: https://atcoder.jp/contests/kupc2013/submissions/6389179
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = "kogakubu10gokan";
        for (int i = 0; i < nq[0]; i++)
        {
            var q = Console.ReadLine().Split();
            if (nq[1] < int.Parse(q[0])) break;
            s = q[1];
        }
        Console.WriteLine(s);
    }
}
