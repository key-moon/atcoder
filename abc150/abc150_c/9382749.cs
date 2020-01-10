// detail: https://atcoder.jp/contests/abc150/submissions/9382749
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
        int n = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var q = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Range(1, n).ToArray();
        int ctr = 0;
        var pind = ctr;
        var qind = ctr;
        foreach (var perm in Permutations(a))
        {
            if (p.Zip(perm, (x, y) => x == y).All(x => x)) pind = ctr;
            if (q.Zip(perm, (x, y) => x == y).All(x => x)) qind = ctr;
            ctr++;
        }
        Console.WriteLine(Abs(pind - qind));
    }


    static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
    {
        int index = 0;
        yield return array;
        while (true)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1].CompareTo(array[i]) >= 0) continue;
                int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
                T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
                Array.Reverse(array, i, array.Length - i);
                yield return array;
                goto end;
            }
            Array.Reverse(array, index, array.Length);
            yield break;
            end:;
        }
    }
}
