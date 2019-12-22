// detail: https://atcoder.jp/contests/arc062/submissions/9092853
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
        int g = 0;
        int p = 0;
        string s = Console.ReadLine();
        int score = 0;
        foreach (var c in s)
        {
            if (p < g)
            {
                if (c == 'g')
                {
                    p++;
                    score++;
                }
                else
                {
                    p++;
                }
            }
            else
            {
                if (c == 'g')
                {
                    g++;
                }
                else
                {
                    g++;
                    score--;
                }
            }
        }
        Console.WriteLine(score);
    }
}
