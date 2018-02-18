// detail: https://atcoder.jp/contests/abc088/submissions/2109294
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[][] c = Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        if (c[0][0] + c[1][1] + c[2][2] == c[0][1] + c[1][2] + c[2][0] && c[0][1] + c[1][2] + c[2][0] == c[0][2] + c[1][0] + c[2][1])
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }    
}
