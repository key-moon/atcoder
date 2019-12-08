// detail: https://atcoder.jp/contests/abc147/submissions/8877066
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int h = hw[0];
        int w = hw[1];
        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); }

        var arrived = new bool[h * w];
        var a = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse)).ToArray().Zip(
            Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().Split().Select(int.Parse)).ToArray(),
            (x, y) => Abs(x - y)
        ).ToArray();
        var offset = 160 * 160;
        BitArray[] diffs = Enumerable.Repeat(0, h * w).Select(_ => new BitArray(offset * 2 + 1)).ToArray();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        diffs[0].SetTrue(offset);
        while (queue.Count != 0)
        {
            var last = queue.Dequeue();
            var newBitArray = new BitArray(diffs[last]);
            diffs[last].ShiftPositive(a[last]);
            newBitArray.ShiftNegative(a[last]);
            diffs[last].Or(newBitArray);
            foreach (var next in graph[last])
            {
                diffs[next].Or(diffs[last]);
                if (arrived[next]) continue;
                arrived[next] = true;
                queue.Enqueue(next);
            }
        }
        var min = int.MaxValue;
        var lastDiff = diffs.Last();
        for (int i = 0; i < lastDiff.Length; i++)
        {
            if (!lastDiff.Get(i)) continue;
            min = Min(min, Abs(offset - i));
        }
        Console.WriteLine(min);
    }
}

class BitArray
{
    public readonly int Length;
    private readonly ulong LastMask;
    ulong[] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BitArray(int length)
    {
        data = new ulong[((length - 1) >> 6) + 1];
        Length = length;
        LastMask = (~0UL) >> ((~length) & 63);
    }
    public BitArray(BitArray bitArray)
    {
        data = new ulong[Length = bitArray.data.Length];
        bitArray.data.CopyTo(data, 0);
        LastMask = bitArray.LastMask;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Get(int index) => (data[index >> 6] >> (index & 63) & 1) == 1;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetTrue(int index) => data[index >> 6] |= (1UL << (index & 63));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetFalse(int index) => data[index >> 6] &= ~(1UL << (index & 63));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Or(BitArray bitArray)
    {
        for (int i = 0; i < data.Length; i++) data[i] |= bitArray.data[i];
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void And(BitArray bitArray)
    {
        for (int i = 0; i < data.Length; i++) data[i] &= bitArray.data[i];
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Xor(BitArray bitArray)
    {
        for (int i = 0; i < data.Length; i++) data[i] ^= bitArray.data[i];
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShiftPositive(int width)
    {
        var blockShiftLength = width >> 6;
        var bitShiftLengtha = width & 63;
        var bitShiftLengthb = 64 - bitShiftLengtha;
        for (int i = data.Length - 1; i >= 0; i--)
        {
            data[i] = ((0 <= i - blockShiftLength ? data[i - blockShiftLength] << bitShiftLengtha : 0) | (bitShiftLengthb != 64 && 0 <= i - blockShiftLength - 1 ? data[i - blockShiftLength - 1] >> bitShiftLengthb : 0));
        }
        data[data.Length - 1] &= LastMask;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ShiftNegative(int width)
    {
        var blockShiftLength = width >> 6;
        var bitShiftLengtha = width & 63;
        var bitShiftLengthb = 64 - bitShiftLengtha;
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = ((i + blockShiftLength < data.Length ? data[i + blockShiftLength] >> bitShiftLengtha : 0) | (bitShiftLengthb != 64 && i + blockShiftLength + 1 < data.Length ? data[i + blockShiftLength + 1] << bitShiftLengthb : 0));
        }
        data[data.Length - 1] &= LastMask;
    }
}
