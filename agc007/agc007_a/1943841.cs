// detail: https://atcoder.jp/contests/agc007/submissions/1943841
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int next = 0;
        for (int i = 0; i < HW[0]; i++)
        {
            string s = Console.ReadLine();
            int count = 0;
            for (int j = next; j < HW[1]; j++)
            {
                if (s[j] != '#') break;
                count++;
                next = j;
            }
            if (s.Count(x => x == '#') != count)
            {
                Console.WriteLine("Impossible");
                return;
            }
        }
        Console.WriteLine("Possible");
    }
}
