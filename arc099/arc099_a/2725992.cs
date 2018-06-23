// detail: https://atcoder.jp/contests/arc099/submissions/2725992
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //最小のものの右、左の個数
        //k-1だったら1回、(k-1)*2だったr
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int minInd = a.ToList().IndexOf(1);
        Console.WriteLine((nk[0] - 1) / (nk[1] - 1) + ((nk[0] - 1) % (nk[1] - 1) != 0 ? 1 : 0));
    }
}
