// detail: https://atcoder.jp/contests/abc113/submissions/3923339
using System;
using Library;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using static System.Math;
using static Reader;

public static class Reader:Object
{
    static TextReader stdinReader = Console.In;

    public static char NextChar => (char)stdinReader.Read();

    public static int NextInt => ReadInt();

    public static IEnumerable<int> NextIntCollection => ReadIntCollection();


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

}


static partial class ArrayOperation
{
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
}


static class Writer
{
public static void WriteLine(this int item) => Console.WriteLine(item);
}


namespace Library
{
public class Program:Object
    {
            static void Main()
            {
                int n = NextInt;
                int t = NextInt;
                int a = NextInt;
                (NextIntCollection.MinIndex(x => Abs(t - x * 0.006 - a)) + 1).WriteLine();
            }

    }
}
