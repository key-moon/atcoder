// detail: https://atcoder.jp/contests/agc021/submissions/2129709
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(solve(long.Parse(Console.ReadLine())));
    }
    static int solve(long i)
    {
        string n = i.ToString();
        int res = 0;
        if (n.Length == 1)
        {
            res = n[0] - '0';
        }
        else if (n[0] != '9')
        {
            if (n.Count(x => x != '9') == 1)
            {
                res = 9 * (n.Length - 1) + (n[0] - '0');
            }
            else
            {
                res = 9 * (n.Length - 1) + (n[0] - '0' - 1);
            }
        }
        else if (n.Count(x => x != '9') != 0)
        {
            res = 9 * (n.Length - 1) + 8;
        }
        else
        {
            res = 9 * (n.Length - 1) + 9;
        }
        return res;
    }
}
