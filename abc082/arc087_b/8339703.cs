// detail: https://atcoder.jp/contests/abc082/submissions/8339703
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int x = 0, y = 0;
        int curDir = 0;
        int curStreak = 0;
        List<int>[] moves = { new List<int>(), new List<int>() };
        bool firstChunk = true;
        foreach (var c in Console.ReadLine() + "T")
        {
            if (c == 'F')
            {
                curStreak++;
            }
            else
            {
                if (firstChunk) x -= curStreak;
                else moves[curDir].Add(curStreak);
                firstChunk = false;
                curDir ^= 1;
                curStreak = 0;
            }
        }

        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        x += xy[0];
        y += xy[1];

        Console.WriteLine(CanAchive(moves[0], x) && CanAchive(moves[1], y) ? "Yes" : "No");
    }

    static bool CanAchive(IEnumerable<int> moves, int cood)
    {
        if (8000 < Abs(cood)) return false;
        HashSet<int> set = new HashSet<int>() { 0 };
        foreach (var move in moves)
        {
            HashSet<int> newSet = new HashSet<int>();
            foreach (var item in set)
            {
                newSet.Add(item + move);
                newSet.Add(item - move);
            }
            set = newSet;
        }
        return set.Contains(cood);
    }
}
 
