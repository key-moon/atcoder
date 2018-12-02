// detail: https://atcoder.jp/contests/abc114/submissions/3703378
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int res = 0;
        int sum753 = 159;
        List<long> cur753 = new List<long>();
        cur753.Add(0);
        while (cur753.Count != 0)
        {
            List<long> new753 = new List<long>();
            foreach (var num in cur753)
            {
                if (num > n) continue;
                if (num.ToString().Distinct().Select(x => (int)x).Sum() == sum753) res++;
                new753.Add(num * 10 + 3);
                new753.Add(num * 10 + 5);
                new753.Add(num * 10 + 7);
            }
            cur753 = new753;
        }
        Console.WriteLine(res);
    }
}
