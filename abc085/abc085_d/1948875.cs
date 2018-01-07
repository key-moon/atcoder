// detail: https://atcoder.jp/contests/abc085/submissions/1948875
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] sword = new int[a[0]][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderByDescending(x => x[0]).ToArray();
        int strongestA = sword[0][0];
        int[] strongerBthanA = sword.Select(x => x[1]).Where(x => x > strongestA).OrderByDescending(x => x).ToArray();
        int HP = a[1];
        int res = 0;
        for (int i = 0; i < strongerBthanA.Length; i++)
        {
            HP -= strongerBthanA[i];
            res++;
            if (HP <= 0) goto end;
        }
        res += HP / strongestA + (HP % strongestA != 0 ? 1 : 0);
        end:;
        Console.WriteLine(res);
    }
}
