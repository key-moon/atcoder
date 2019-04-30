// detail: https://atcoder.jp/contests/iroha2019-day1/submissions/5196419
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;

static class P
{
    static void Main()
    {
        string n = Console.ReadLine();
        if (n.Length == 1)
        {
            Console.WriteLine($"1{int.Parse(n) - 1}");
            return;
        }
        int sum = n.Sum(x => x - '0');
        string res = "";
        while (sum != 0)
        {
            if (sum >= 9)
            {
                res = "9" + res;
                sum -= 9;
            }
            else
            {
                res = sum.ToString() + res;
                sum -= sum;
            }
        }
        if (res == n)
        {
            var f = res[0] - '0';
            var s = res[1] - '0';
            if(f == 9)
            {
                f = 18;
            }
            else
            {
                f++;
                s--;
            }
            var remain = res.Length == 2 ? "" : res.Substring(2);
            res = $"{f}{s}{remain}";
        }
        Console.WriteLine(res);

    }
}
