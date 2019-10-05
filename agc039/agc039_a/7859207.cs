// detail: https://atcoder.jp/contests/agc039/submissions/7859207
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        var k = long.Parse(Console.ReadLine());
        if (s.Distinct().Count() == 1)
        {
            Console.WriteLine(s.Length * k / 2);
            return; 
        }
        bool isFirst = true;
        char firstChar = '*';
        int firstStreak = 0;
        long res = 0;
        char lastChar = s[0];
        int curStreak = 0;
        foreach (var c in s)
        {
            if (c != lastChar)
            {
                if (isFirst)
                {
                    firstChar = lastChar;
                    firstStreak = curStreak;
                    isFirst = false;
                }
                else res += curStreak / 2;
                curStreak = 0;
            }
            lastChar = c;
            curStreak++;
        }
        res *= k;
        if (firstChar != lastChar)
        {
            res += (firstStreak / 2) * k;
            res += (curStreak / 2) * k;
        }
        else
        {
            res += firstStreak / 2;
            res += curStreak / 2;
            res += ((firstStreak + curStreak) / 2) * (k - 1);
        }
        Console.WriteLine(res);
    }
}
