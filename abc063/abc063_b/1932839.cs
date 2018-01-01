// detail: https://atcoder.jp/contests/abc063/submissions/1932839
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        bool[] b = new bool[26];
        foreach (var c in s)
        {
            if(b[c - 'a'])
            {
                Console.WriteLine("no");
                return;
            }
            b[c - 'a'] = true;
        }
        Console.WriteLine("yes");
    }
}
