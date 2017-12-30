// detail: https://atcoder.jp/contests/abc084/submissions/1922546
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        bool b = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (i != a[0])
            {
                if (!char.IsDigit(s[i]))
                {
                    b = false;
                }
            }
            else
            {
                if (s[i] != '-')
                {
                    b = false;
                }
            }
        }
        Console.WriteLine(b ? "Yes" : "No");
    }
}
