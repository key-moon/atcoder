// detail: https://atcoder.jp/contests/abc049/submissions/1932953
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] s = new string[HW[0]].Select(_ => Console.ReadLine()).ToArray();

        for (int i = 0; i < HW[0]; i++)
        {
            Console.WriteLine(s[i]);
            Console.WriteLine(s[i]);
        }
    }
}
