// detail: https://atcoder.jp/contests/abc009/submissions/9366152
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        string s = Console.ReadLine();

        int prefixDiff = 0;
        string prefix = "";
        List<char> remainChar = s.ToList();
        for (int i = 0; i < n; i++)
        {
            for (int c = 0; c < 26; c++)
            {
                var target = (char)('a' + c);
                if (!remainChar.Contains(target)) continue;
                remainChar.Remove(target);
                var nextPrefixDiff = prefixDiff + (target != s[i] ? 1 : 0);
                var nextDiff = nextPrefixDiff + MaxDiff(s.Substring(i + 1), remainChar);
                if (k < nextDiff)
                {
                    remainChar.Add(target);
                    continue;
                }
                prefix += target;
                prefixDiff = nextPrefixDiff;
                goto end;
            }
            throw new Exception();
            end:;
        }
        Console.WriteLine(prefix);
    }

    public static int MaxDiff(string target, List<char> charList)
    {
        int[] c = new int[26];
        for (int i = 0; i < target.Length; i++)
            c[target[i] - 'a']++;
        for (int i = 0; i < charList.Count; i++)
            c[charList[i] - 'a']--;
        return c.Sum(Abs) / 2;
    }
}
