// detail: https://atcoder.jp/contests/abc124/submissions/4946646
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine();

        List<int> streaks = new List<int>();
        if (s[0] != '1') streaks.Add(0);
        int current = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i - 1] == s[i]) current++;
            else
            {
                streaks.Add(current);
                current = 1;
            }
        }
        streaks.Add(current);
        if (s.Last() != '1') streaks.Add(0);

        int res = 0;
        int currentSum = 0;
        var end = Min(streaks.Count, nk[1] * 2 + 1);
        for (int i = 0; i < end; i++)
        {
            currentSum += streaks[i];
        }
        res = currentSum;
        for (int i = end; i < streaks.Count;)
        {
            currentSum += streaks[i];
            currentSum -= streaks[i - end];
            i++;
            currentSum += streaks[i];
            currentSum -= streaks[i - end];
            i++;
            res = Max(res, currentSum);
        }
        Console.WriteLine(res);
    }
}
