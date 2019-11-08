// detail: https://atcoder.jp/contests/arc038/submissions/8339927
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using System.Runtime.CompilerServices;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var map = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        var gonnaWin = Enumerable.Repeat(0, h).Select(_ => new bool[w]).ToArray();

        gonnaWin[h - 1][w - 1] = map[h - 1][w - 1] == '#';
        for (int i = h - 2; i >= 0; i--)
        {
            if (map[i][w - 1] == '#') gonnaWin[i][w - 1] = true;
            else gonnaWin[i][w - 1] = !gonnaWin[i + 1][w - 1];
        }
        for (int j = w - 2; j >= 0; j--)
        {
            if (map[h - 1][j] == '#') gonnaWin[h - 1][j] = true;
            else gonnaWin[h - 1][j] = !gonnaWin[h - 1][j + 1];
        }

        for (int i = h - 2; i >= 0; i--)
        {
            for (int j = w - 2; j >= 0; j--)
            {
                if (map[i][j] == '#') gonnaWin[i][j] = true;
                else gonnaWin[i][j] = !gonnaWin[i + 1][j] | !gonnaWin[i][j + 1] | !gonnaWin[i + 1][j + 1];
            }
        }

        Console.WriteLine(gonnaWin[0][0] ? "First" : "Second");
    }
}
 
