// detail: https://atcoder.jp/contests/wupc2nd/submissions/2134413
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 1; i <= nm[0]; i++)
        {
            res += i * i;
            res %= nm[1];
            //Console.WriteLine(res);
        }
        Console.WriteLine(res);
    }
}
