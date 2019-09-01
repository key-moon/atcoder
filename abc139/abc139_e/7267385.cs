// detail: https://atcoder.jp/contests/abc139/submissions/7267385
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        int[] nextOpponent = new int[n + 1];
        for (int i = 0; i < n; i++)
            nextOpponent[i] = a[i][0];
        nextOpponent[n] = n;
        int[] index = new int[n];
        List<int> nextDayMatch = nextOpponent.Take(n).Where((x, y) => /*next[y] == x &&*/nextOpponent[x] == y).ToList();
        int remainCount = n;
        int turn = 0;
        while (remainCount > 0)
        {
            if (nextDayMatch.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            foreach (var next in nextDayMatch)
            {
                index[next]++;
                if (index[next] >= a[next].Length)
                {
                    nextOpponent[next] = n;
                    remainCount--;
                    continue;
                }
                nextOpponent[next] = a[next][index[next]];
            }
            List<int> newNextDay = new List<int>();
            foreach (var next in nextDayMatch)
            {
                //可能性がある人
                var op = nextOpponent[next];
                //両思いだったら
                if (next == nextOpponent[op])
                {
                    newNextDay.Add(next);
                    newNextDay.Add(op);
                }
            }
            nextDayMatch = newNextDay.Distinct().ToList();
            turn++;
        }
        Console.WriteLine(turn);
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            int rev = 1;
            while (45 > next || next > 57) next = In.Read();
            if (next == 45) { next = In.Read(); rev = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res * rev;
        }
    }
}
