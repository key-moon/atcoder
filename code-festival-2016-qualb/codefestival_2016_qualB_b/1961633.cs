// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/1961633
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        int all = 0;
        int bcount = 0;

        bool b = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (b)
            {
                switch (s[i])
                {
                    case 'a':
                    Console.WriteLine("Yes");
                    all++;
                    break;
                    case 'b':
                    if (bcount < A[2])
                    {
                        Console.WriteLine("Yes");
                        all++;
                        bcount++;
                    }
                    else Console.WriteLine("No");
                    break;
                    default:
                    Console.WriteLine("No");
                    break;
                }
            }
            else
            {
                Console.WriteLine("No");
            }
            if (all >= A[1] + A[2]) b = false;
        }
    }
}
