// detail: https://atcoder.jp/contests/sumitrust2019/submissions/9929236
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        HashSet<string> set = new HashSet<string>();
        HashSet<string> res = new HashSet<string>();
        set.Add("");
        foreach (var c in s)
        {
            HashSet<string> newSet = new HashSet<string>();
            foreach (var item in set)
            {
                newSet.Add(item);
                if (item.Length == 2) res.Add(item + c);
                else newSet.Add(item + c);
            }
            set = newSet;
        }
        Console.WriteLine(res.Count);
    }
}
