// detail: https://atcoder.jp/contests/agc036/submissions/6495321
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //偶奇で循環しそう←ごどく
        //まあどこかで循環しそうで
        //順関節割り出してシミュレーション?
        //多分グループに分けられて、
        //範囲が消えるから後ろがつながるみたいなそういうこと?
        //消えるところまで移動→その次 で配列の先頭が求められる
        int[] hop = new int[a.Length + 1];
        int[] next = new int[a.Length + 1];
        {
            hop[n] = n;
            List<int>[] shouldCameHere = Enumerable.Repeat(0, a.Length + 1).Select(_ => new List<int>()).ToArray();
            shouldCameHere[0].Add(a.Length);
            int[] beforeInd = Enumerable.Repeat(-1, 200001).ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (beforeInd[a[i]] != -1)
                {
                    hop[beforeInd[a[i]]] = i;

                    shouldCameHere[i + 1] = shouldCameHere[beforeInd[a[i]]];
                    shouldCameHere[beforeInd[a[i]]] = new List<int>();
                }
                shouldCameHere[i + 1].Add(i);
                beforeInd[a[i]] = i;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (beforeInd[a[i]] != -1)
                {
                    hop[beforeInd[a[i]]] = i;
                }
                beforeInd[a[i]] = -1;
            }
            for (int i = 0; i < shouldCameHere.Length; i++)
            {
                for (int j = 0; j < shouldCameHere[i].Count; j++)
                {
                    next[shouldCameHere[i][j]] = i;
                }
            }
        }
        var cycle = GetCycleCount(n, hop, next);
        Console.WriteLine(string.Join(" ", Solve(n, (int)(k % cycle), hop, next, a)));

    }

    static IEnumerable<int> Solve(int n, int k, int[] hop, int[] next, int[] a)
    {
        int ptr = n;
        for (int iterate = 0; iterate < k; iterate++)
        {
            ptr = next[hop[ptr]];
        }
        var stack = new Stack<int>();
        Simulation(a.Skip(ptr).ToArray(), stack);
        return stack.Reverse();
    }

    static int GetCycleCount(int n, int[] hop, int[] next)
    {
        int ptr = n;
        int count = 0;
        do
        {
            ptr = next[hop[ptr]];
            count++;
        } while (ptr != n);
        return count;
    }

    static void Simulation(int[] a, Stack<int> state)
    {
        HashSet<int> has = new HashSet<int>(state);
        int ptr = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (has.Contains(a[i]))
            {
                while (has.Contains(a[i]))
                {
                    has.Remove(state.Pop());
                }
                continue;
            }
            state.Push(a[i]);
            has.Add(a[i]);
        }
    }
}
