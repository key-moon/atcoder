// detail: https://atcoder.jp/contests/cf16-final-open/submissions/1931518
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string res = "";
        for (int i = 0; i < HW[0]; i++)
        {
            string[] s = Console.ReadLine().Split();
            for (int j = 0; j < HW[1]; j++)
            {
                if (s[j] == "snuke")
                {
                    res = $"{char.ConvertFromUtf32('A' + j)}{i + 1}";
                }
            }
        }
        Console.WriteLine(res);
    }
}
