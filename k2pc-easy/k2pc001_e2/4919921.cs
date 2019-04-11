// detail: https://atcoder.jp/contests/k2pc-easy/submissions/4919921
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var StreakResistance = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
        int[] MaxStreak = new int[7];
        int[] CurrentStrek = new int[7];
        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();
            for (int j = 0; j < 7; j++)
            {
                if (s[j] == 'X') CurrentStrek[j]++;
                else CurrentStrek[j] = 0;
                MaxStreak[j] = Max(MaxStreak[j], CurrentStrek[j]);
            }
        }
        Console.WriteLine(MaxStreak.OrderByDescending(x => x).Zip(StreakResistance, (x, y) => x <= y).All(x => x) ? "YES" : "NO");
    }
}
