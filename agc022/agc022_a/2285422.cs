// detail: https://atcoder.jp/contests/agc022/submissions/2285422
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        if (s.Length != 26)
        {
            char[] c = s.ToArray();
            bool[] isUsed = new bool[26];
            for (int i = 0; i < c.Length; i++) isUsed[c[i] - 'a'] = true;
            for (int i = 0; i < 26; i++)
            {
                if (!isUsed[i])
                {
                    Console.WriteLine($"{s}{char.ConvertFromUtf32(i + 'a')}");
                    break;
                }
            }
        }
        else if (s == "zyxwvutsrqponmlkjihgfedcba")
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(nextString(s));
        }
    }
    static string nextString(string s)
    {
        List<char> c = s.ToList();
        bool[] isUsed = new bool[26];
        for (int i = 0; i < c.Count; i++) isUsed[c[i] - 'a'] = true;
        for (int i = c.Count - 1; i >= 0; i--)
        {
            char item = c[i];
            for (int j = item - 'a'; j < isUsed.Length; j++)
            {
                if (!isUsed[j])
                {
                    c[i] = char.ConvertFromUtf32(j + 'a')[0];
                    goto end;
                }
            }
            isUsed[item - 'a'] = false;
            c.RemoveAt(c.Count - 1);
        }
        end:;
        return string.Join("", c);
    }
    static bool isTasai(string s) => s.Distinct().Count() == s.Count();
}
