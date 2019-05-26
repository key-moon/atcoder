// detail: https://atcoder.jp/contests/abc128/submissions/5637901
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var switches = new int[nm[0]];
        for (int i = 0; i < nm[1]; i++)
        {
            foreach (var s in Console.ReadLine().Split().Select(int.Parse).Skip(1))
            {
                switches[s - 1] |= 1 << i;
            }
        }
        int valid = 0;
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < nm[1]; i++)
        {
            valid |= p[i] << i;
        }
        int count = 0;
        for (int i = 0; i < (1 << switches.Length); i++)
        {
            int res = 0;
            for (int j = 0; j < switches.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    res ^= switches[j];
                }
            }
            if (res == valid) count++;
        }
        Console.WriteLine(count);
    }
}
