// detail: https://atcoder.jp/contests/cf17-final-open/submissions/4418682
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        //要するに同じ文字は連続してはいけない、ある文字を挟んで文字が2つあってはいけない(4文字以上の回文はn-2文字の回文を消すと自動で消えてくれる)
        int aCount = s.Count(x => x == 'a');
        int bCount = s.Count(x => x == 'b');
        int cCount = s.Count(x => x == 'c');
        int[] abc = new int[] { aCount, bCount, cCount }.OrderByDescending(x => x).ToArray();
        Console.WriteLine(abc.Max() - abc.Min() <= 1 ? "YES" : "NO");
    }
}
