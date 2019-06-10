// detail: https://atcoder.jp/contests/arc072/submissions/5868240
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nd[0];
        var D = nd[1];
        var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] firstDeadPlace = new long[n + 1];
        firstDeadPlace[n] = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (firstDeadPlace[i + 1] < d[i] / 2 + 1)
            {
                firstDeadPlace[i] = firstDeadPlace[i + 1];
                continue;
            }
            firstDeadPlace[i] = Min(int.MaxValue, firstDeadPlace[i + 1] + d[i]);
        }

        long currentPlace = D;
        bool alreadyArrived = false;
        bool[] canDisturb = new bool[n];
        for (int i = 0; i < canDisturb.Length; i++)
        {
            canDisturb[i] = firstDeadPlace[i + 1] <= currentPlace && !alreadyArrived;
            currentPlace = Min(currentPlace, Abs(currentPlace - d[i]));
            alreadyArrived |= currentPlace == 0;
        }
        Console.ReadLine();
        Console.WriteLine(string.Join("
", Console.ReadLine().Split().Select(x => canDisturb[int.Parse(x) - 1] ? "YES" : "NO")));
    }
}
