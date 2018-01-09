// detail: https://atcoder.jp/contests/arc053/submissions/1958356
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((hw[0] - 1) * hw[1] + (hw[1] - 1) * hw[0]);

    }
}
