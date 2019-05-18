// detail: https://atcoder.jp/contests/agc020/submissions/5433445
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
        BitArray bits = new BitArray(2000 * 2000 + 1);
        bits.SetTrue(0);
        var n = Read();
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            var num = Read();
            sum += num;
            bits.OrWithShiftPositive(num);
        }
        for (int i = (sum / 2) + (sum & 1); ; i++)
        {
            if (bits.Get(i))
            {
                Console.WriteLine(i);
                return;
            }
        }
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
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = ((0 <= i - blockShiftLength ? data[i - blockShiftLength] << bitShiftLengtha : 0) | (bitShiftLengthb != 64 && 0 <= i - blockShiftLength - 1 ? data[i - blockShiftLength - 1] >> bitShiftLengthb : 0));
        }
        data[data.Length - 1] &= LastMask;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void OrWithShiftPositive(int width)
    {
        var blockShiftLength = width >> 6;
        var bitShiftLengtha = width & 63;
        var bitShiftLengthb = 64 - bitShiftLengtha;
        //
        //------|---
        //|--------|
        for (int i = data.Length - 1; i >= 0; i--)
        {
            data[i] |= ((0 <= i - blockShiftLength ? data[i - blockShiftLength] << bitShiftLengtha : 0) | (bitShiftLengthb != 64 && 0 <= i - blockShiftLength - 1 ? data[i - blockShiftLength - 1] >> bitShiftLengthb : 0));
        }
        data[data.Length - 1] &= LastMask;
    }
}
