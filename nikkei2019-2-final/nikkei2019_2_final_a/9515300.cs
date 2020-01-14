// detail: https://atcoder.jp/contests/nikkei2019-2-final/submissions/9515300
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var compress = a.Distinct().OrderByDescending(x => x).Select((Elem, Count) => new { Elem, Count }).ToDictionary(x => x.Elem, x => x.Count);

        long res = 0;
        for (int i = 0; i < n; i++)
        {
            //一点加算/区間和が可能なBinary Indexed Tree(BIT)
            BIT<int> bit = new BIT<int>(compress.Count, 0, (x, y) => x + y);
            for (int k = i + 1; k < n; k++)
            {
                //max(a_i, a_k)より大きい要素の数の和(座標圧縮先のindexに直してからquery)
                res += bit.Query(compress[Max(a[i], a[k])]);
                //今の点についてBITに追加
                bit.Operate(compress[a[k]], 1);
            }
        }
        Console.WriteLine(res);
    }
}


class BIT<T>
{
    public readonly int Size;
    T Identity;
    T[] Elements;
    Func<T, T, T> Merge;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BIT(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Elements = new T[Size + 1];
        for (int i = 0; i < Elements.Length; i++) Elements[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int r)
    {
        T res = Identity;
        for (; r > 0; r -= r & -r) res = Merge(res, Elements[r]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        for (i++; i < Elements.Length; i += i & -i) Elements[i] = Merge(Elements[i], x);
    }
}
