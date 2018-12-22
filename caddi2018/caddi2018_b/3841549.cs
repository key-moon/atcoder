// detail: https://atcoder.jp/contests/caddi2018/submissions/3841549
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        //全てが偶数になった状態で相手にわたれば良い
        Console.WriteLine(a.All(x => x % 2 == 0) ? "second" : "first");
    }
}
