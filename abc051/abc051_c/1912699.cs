// detail: https://atcoder.jp/contests/abc051/submissions/1912699
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class P
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int sx = input[0];
        int sy = input[1];
        int tx = input[2];
        int ty = input[3];

        string res = "";

        for (int i = sx; i < tx; i++)
        {
            res += "R";
        }
        for (int i = sy; i < ty; i++)
        {
            res += "U";
        }
        for (int i = tx; i > sx; i--)
        {
            res += "L";
        }
        for (int i = ty; i > sy; i--)
        {
            res += "D";
        }

        res += "D";

        for (int i = sx; i < tx + 1; i++)
        {
            res += "R";
        }
        for (int i = sy - 1; i < ty; i++)
        {
            res += "U";
        }

        res += "L";
        res += "U";

        for (int i = tx; i > sx - 1; i--)
        {
            res += "L";
        }
        for (int i = ty + 1; i > sy; i--)
        {
            res += "D";
        }

        res += "R";
        Console.WriteLine(res);
    }
}
