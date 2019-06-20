// detail: https://atcoder.jp/contests/joi2009yo/submissions/6034283
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = Read();
        var m = Read();
        var p = Read();
        var q = Read();
        var r = Read();
        List<CardChunk> pile = new List<CardChunk>();
        pile.Add(new CardChunk(1, r));
        pile.Add(new CardChunk(0, n - r));
        for (int i = 0; i < m; i++)
        {
            var x = Read();
            var y = Read();
            List<CardChunk> pileA = new List<CardChunk>();
            List<CardChunk> pileB = new List<CardChunk>();
            List<CardChunk> pileC = new List<CardChunk>();
            int count = 0;
            foreach (var chunk in pile)
            {
                var currentChunk = chunk;
                if (count + currentChunk.Count < x)
                {
                    pileA.Add(currentChunk);
                    count += currentChunk.Count;
                    continue;
                }
                if (count < x && x <= count + currentChunk.Count)
                {
                    pileA.Add(new CardChunk(currentChunk.Color, x - count));
                    currentChunk = new CardChunk(currentChunk.Color, currentChunk.Count - (x - count));
                    count = x; //count += (x - count);
                    if (currentChunk.Count == 0) continue;
                }
                if (count + currentChunk.Count < y)
                {
                    pileB.Add(currentChunk);
                    count += currentChunk.Count;
                    continue;
                }
                if (count < y && y <= count + currentChunk.Count)
                {
                    pileB.Add(new CardChunk(currentChunk.Color, y - count));
                    currentChunk = new CardChunk(currentChunk.Color, currentChunk.Count - (y - count));
                    count = y; //count += (x - count);
                    if (currentChunk.Count == 0) continue;
                }
                pileC.Add(currentChunk);
            }
            pileC.AddRange(pileB);
            pileC.AddRange(pileA);
            pile = pileC;
        }
        int res = 0;
        {
            int count = 0;
            foreach (var chunk in pile)
            {
                if (chunk.Color == 1)
                {
                    //前にある分
                    res += chunk.Count;
                    res -= Min(chunk.Count, Max(0, p - count - 1));
                    res -= Min(chunk.Count, Max(0, count + chunk.Count - q));
                }
                count += chunk.Count;
            }
        }
        Console.WriteLine(res);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int Read()
    {
        int res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
    }
}

struct CardChunk
{
    public int Color;
    public int Count;
    public CardChunk(int color, int count)
    {
        Color = color;
        Count = count;
    }
}
