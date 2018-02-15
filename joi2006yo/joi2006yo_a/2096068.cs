// detail: https://atcoder.jp/contests/joi2006yo/submissions/2096068
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] score = new int[2];
        for (int i = 0; i < n; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (ab[0] > ab[1])
            {
                score[0] += ab.Sum();
            }
            else if(ab[0] < ab[1])
            {
                score[1] += ab.Sum();
            }
            else
            {
                score[0] += ab[0];
                score[1] += ab[1];
            }
        }
        Console.WriteLine(string.Join(" ",score));
    }
}
