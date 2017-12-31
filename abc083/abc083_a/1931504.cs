// detail: https://atcoder.jp/contests/abc083/submissions/1931504
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(A[0] + A[1] == A[2] + A[3] ? "Balanced" : (A[0] + A[1] > A[2] + A[3] ? "Left" : "Right"));
    }
}
