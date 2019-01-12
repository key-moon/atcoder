// detail: https://atcoder.jp/contests/aising2019/submissions/3986178
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static Reader;
using static System.Math;

class P
{
    static void Main()
    {
        int n = NextInt;
        int a = NextInt;
        int b = NextInt;
        int[] p = NextIntCollection.ToArray();
        (Min(Min(p.Count(x => x <= a), p.Count(x => a < x && x <= b)), p.Count(x => b < x))).WriteLine();
    }
}

#region io
static class Reader
{
    static TextReader stdinReader = Console.In;

    public static char NextChar => (char)stdinReader.Read();
    public static int NextInt => ReadInt();
    public static long NextLong => ReadLong();
    public static string NextString => ReadString();
    public static IEnumerable<int> NextIntCollection => ReadIntCollection();
    public static IEnumerable<long> NextLongCollection => ReadLongCollection();
    public static IEnumerable<string> NextStringCollection => ReadStringCollection();
    public static string NextLine => stdinReader.ReadLine();

    public static int ReadInt()
    {
        int i;
        bool isNegative;
        checked
        {
            i = 0;
            isNegative = false;
            char next = NextChar;
            while (char.IsWhiteSpace(next)) next = NextChar;
            while (true)
            {
                if (!char.IsDigit(next))
                {
                    if (next == '-')
                    {
                        isNegative = true;
                    }
                    else if (next != '+') break;
                }
                else
                {
                    i *= 10;
                    i += next - '0';
                }
                next = NextChar;
            }
        }
        return isNegative ? -i : i;
    }

    public static long ReadLong()
    {
        long i;
        bool isNegative;
        checked
        {
            i = 0;
            isNegative = false;
            char next = NextChar;
            while (char.IsWhiteSpace(next)) next = NextChar;
            while (true)
            {
                if (!char.IsDigit(next))
                {
                    if (next == '-')
                    {
                        isNegative = true;
                    }
                    else if (next != '+') break;
                }
                else
                {
                    i *= 10;
                    i += next - '0';
                }
                next = NextChar;
            }
        }
        return isNegative ? -i : i;
    }

    public static string ReadString()
    {
        StringBuilder builder = new StringBuilder();
        char next = NextChar;
        while (char.IsWhiteSpace(next)) next = NextChar;
        while (true)
        {
            if (char.IsWhiteSpace(next)) break;
            builder.Append(next);
            next = NextChar;
        }
        return builder.ToString();
    }

    public static IEnumerable<int> ReadIntCollection()
    {
        int i;
        bool isNegative;
        char next;
        while (true)
        {
            i = 0;
            isNegative = false;
            next = NextChar;
            while (char.IsWhiteSpace(next)) next = NextChar;
            while (true)
            {
                if (!char.IsDigit(next))
                {
                    if (next == '-')
                    {
                        isNegative = true;
                    }
                    else if (next != '+') break;
                }
                else
                {
                    i *= 10;
                    i += next - '0';
                }
                next = NextChar;
            }
            yield return isNegative ? -i : i;
            if (!char.IsSeparator(next)) break;
        }
    }

    public static IEnumerable<long> ReadLongCollection()
    {
        long i;
        bool isNegative;
        char next;
        while (true)
        {
            i = 0;
            isNegative = false;
            next = NextChar;
            while (char.IsWhiteSpace(next)) next = NextChar;
            while (true)
            {
                if (!char.IsDigit(next))
                {
                    if (next == '-')
                    {
                        isNegative = true;
                    }
                    else if (next != '+') break;
                }
                else
                {
                    i *= 10;
                    i += next - '0';
                }
                next = NextChar;
            }
            yield return isNegative ? -i : i;
            if (!char.IsSeparator(next)) break;
        }
    }

    public static IEnumerable<string> ReadStringCollection()
    {
        StringBuilder builder = new StringBuilder();
        char next;
        while (true)
        {
            builder.Clear();
            next = NextChar;
            while (char.IsWhiteSpace(next)) next = NextChar;
            while (true)
            {
                if (char.IsWhiteSpace(next)) break;
                builder.Append(next);
                next = NextChar;
            }
            yield return builder.ToString();
            if (!char.IsSeparator(next)) break;
        }
    }
}

static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
#endregion

#region arrayoperation
static class ArrayOperation
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Compress<T>(this IEnumerable<T> enumerable) where T : IComparable<T>
    {
        var dict = enumerable.OrderBy(x => x).Distinct().Select((x, y) => new Tuple<T, int>(x, y)).ToDictionary(x => x.Item1, x => x.Item2);
        return enumerable.Select(x => dict[x]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Exists<T>(this IEnumerable<T> enumerable, Func<T, bool> selector)
    {
        foreach (var item in enumerable) if (selector(item)) return true;
        return false;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable) action(item);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T1 MinElement<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> selector) where T2 : IComparable<T2>
    {
        T1 minElem = default(T1);
        T2 min = default(T2);
        bool isFirst = true;
        foreach (var item in enumerable)
        {
            var next = selector(item);
            if (min.CompareTo(next) > 0 || isFirst)
            {
                isFirst = false;
                minElem = item;
                min = next;
            }
        }
        return minElem;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T1 MaxElement<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> selector) where T2 : IComparable<T2>
    {
        T1 maxElem = default(T1);
        T2 max = default(T2);
        bool isFirst = true;
        foreach (var item in enumerable)
        {
            var next = selector(item);
            if (max.CompareTo(next) < 0 || isFirst)
            {
                isFirst = false;
                maxElem = item;
                max = next;
            }
        }
        return maxElem;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MinIndex<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> selector) where T2 : IComparable<T2>
    {
        int currentInd = 0;
        int maxInd = 0;
        T2 max = default(T2);
        bool isFirst = true;
        foreach (var item in enumerable)
        {
            var next = selector(item);
            if (max.CompareTo(next) > 0 || isFirst)
            {
                isFirst = false;
                max = next;
                maxInd = currentInd;
            }
            currentInd++;
        }
        return maxInd;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MaxIndex<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> selector) where T2 : IComparable<T2>
    {
        int currentInd = 0;
        int maxInd = 0;
        T2 max = default(T2);
        bool isFirst = true;
        foreach (var item in enumerable)
        {
            var next = selector(item);
            if (max.CompareTo(next) < 0 || isFirst)
            {
                isFirst = false;
                max = next;
                maxInd = currentInd;
            }
            currentInd++;
        }
        return maxInd;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable) => enumerable.OrderBy(_ => RNG.NextULong());
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToString<T>(this IEnumerable<T> enumerable, string separator = " ") => string.Join(separator, enumerable);
}
#endregion

#region utils
static class RNG
{
    private static ulong _xorshift_x = (ulong)DateTime.Now.Ticks * 0x3141592c0ffee;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool NextBool() => (NextULong() & 1) == 1;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte NextSByte()
    {
        unchecked
        {
            return (sbyte)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte NextSByte(sbyte MinValue, sbyte MaxValue) => (sbyte)(NextSByte() % (MaxValue - MinValue) + MinValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte NextByte()
    {
        unchecked
        {
            return (byte)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte NextByte(byte MinValue, byte MaxValue) => (byte)(NextByte() % (MaxValue - MinValue) + MinValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short NextShort()
    {
        unchecked
        {
            return (short)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short NextShort(short MinValue, short MaxValue) => (short)(NextShort() % (MaxValue - MinValue) + MinValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort NextUShort()
    {
        unchecked
        {
            return (ushort)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort NextUShort(ushort MinValue, ushort MaxValue) => (ushort)(NextUShort() % (MaxValue - MinValue) + MinValue);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int NextInt()
    {
        unchecked
        {
            return (int)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int NextInt(int MinValue, int MaxValue) => NextInt() % (MaxValue - MinValue) + MinValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint NextUInt()
    {
        unchecked
        {
            return (uint)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint NextUInt(uint MinValue, uint MaxValue) => NextUInt() % (MaxValue - MinValue) + MinValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long NextLong()
    {
        unchecked
        {
            return (long)NextULong();
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long NextLong(long MinValue, long MaxValue) => NextLong() % (MaxValue - MinValue) + MinValue;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong NextULong()
    {
        _xorshift_x = _xorshift_x ^ (_xorshift_x << 7);
        _xorshift_x = _xorshift_x ^ (_xorshift_x >> 9);
        return _xorshift_x;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong NextULong(ulong MinValue, ulong MaxValue) => NextULong() % (MaxValue - MinValue) + MinValue;
}
#endregion
