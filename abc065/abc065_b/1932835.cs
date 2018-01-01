// detail: https://atcoder.jp/contests/abc065/submissions/1932835
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());
        int[] N = new int[n].Select(x => int.Parse(Console.ReadLine())).ToArray();
        int pos = 1;
        int res = 0;
        while (true)
        {
            if (N[pos - 1] == -1)
            {
                res = -1;
                break;
            }
            int temp = N[pos - 1];
            N[pos - 1] = -1;
            pos = temp;
            res++;
            if (pos == 2) break;
        }
        Console.WriteLine(res);
    }
}
