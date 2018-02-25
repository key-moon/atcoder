// detail: https://atcoder.jp/contests/abc054/submissions/2136716
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] path = Enumerable.Repeat(0, 8).Select(_ => new bool[8]).ToArray();
        for (int i = 0; i < nm[1]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            path[ab[0] - 1][ab[1] - 1] = true;
            path[ab[1] - 1][ab[0] - 1] = true;
        }
        int res = 0;
        int[] perm = Enumerable.Range(0, nm[0]).ToArray();
        do
        {
            //Console.WriteLine(string.Join(" ", perm));
            if (perm[0] != 0) break;
            for (int j = 0; j < nm[0] - 1; j++)
            {
                if (!path[perm[j]][perm[j + 1]])
                {
                    goto end;
                }
            }
            res++;
            end:;
        }
        while (NextPermutation(perm));
        Console.WriteLine(res);
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
