// detail: https://atcoder.jp/contests/abc071/submissions/1932801
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int N = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        for (int i = 0; i < 26; i++)
        {
            if (!s.Contains(char.ConvertFromUtf32('a' + i)))
            {
                Console.WriteLine(char.ConvertFromUtf32('a' + i));
                return;
            }
        }
        Console.WriteLine("None");
    }
}
