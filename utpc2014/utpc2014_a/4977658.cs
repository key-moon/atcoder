// detail: https://atcoder.jp/contests/utpc2014/submissions/4977658
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
        var s = Console.ReadLine().Split();
        int notCount = 0;
        List<string> res = new List<string>();
        foreach (var word in s)
        {
            if (word == "not") notCount++;
            else
            {
                if (notCount % 2 == 1) res.Add("not");
                res.Add(word);
                notCount = 0;
            }
        }
        res.AddRange(Enumerable.Repeat("not", notCount));
        Console.WriteLine(string.Join(" ", res));
    }
}
