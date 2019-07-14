// detail: https://atcoder.jp/contests/ttpc2015/submissions/6390006
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        var chars = s.Distinct().OrderBy(x => x).ToArray();
        if (chars.Length >= 6)
        {
            Console.WriteLine(-1);
            return;
        } 
        var converts = new char[] { '1', '3', '5', '7', '9' };
        do
        {
            string cand = s;
            for (int i = 0; i < chars.Length; i++)
            {
                cand = cand.Replace(chars[i], converts[i]);
            }
            if (Factors(long.Parse(cand)).Count() == 1)
            {
                Console.WriteLine(cand);
                return;
            }

        } while (NextPermutation(converts));
        Console.WriteLine(-1);
    }


    static IEnumerable<long> Factors(long n)
    {
        while (n % 2 == 0)
        {
            n /= 2;
            yield return 2;
        }
        long i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                n /= i;
                yield return i;
            }
            else i += 2;
        }
        if (n != 1) yield return n;
    }

    public static void Swap<T>(ref T x, ref T y) { T tmp = x; x = y; y = tmp; }

    public static bool NextPermutation<T>(T[] array, int index, int length, Comparison<T> comp)
    {
        if (length <= 1) return false;
        for (int i = length - 1; i > 0; i--)
        {
            int k = i - 1;
            if (comp(array[k], array[i]) < 0)
            {
                int j = Array.FindLastIndex(array, delegate (T x) { return comp(array[k], x) < 0; });
                Swap(ref array[k], ref array[j]);
                Array.Reverse(array, i, length - i);
                return true;
            }
        }
        Array.Reverse(array, index, length);
        return false;
    }

    public static bool NextPermutation<T>(T[] array) where T : IComparable
    {
        return NextPermutation(array, 0, array.Length, Comparer<T>.Default.Compare);
    }
}
