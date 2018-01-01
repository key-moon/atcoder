// detail: https://atcoder.jp/contests/abc066/submissions/1932825
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        for (int i = 2; i < s.Length; i += 2)
        {
            string subs = s.Substring(0, s.Length - i);
            if (subs.Substring(0,subs.Length / 2) == subs.Substring(subs.Length / 2, subs.Length / 2))
            {
                Console.WriteLine(subs.Length);
                return;
            }
        }
    }
}
