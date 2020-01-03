// detail: https://atcoder.jp/contests/arc098/submissions/9298916
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
        var nkq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nkq[0];
        var k = nkq[1];
        var q = nkq[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        var allSection = new Section() { Start = 0, End = n - 1 };
        Section[] sections = Enumerable.Repeat(allSection, n).ToArray();
        
        var minInd = a.Select((Elem, Ind) => new { Elem, Ind }).OrderBy(x => x.Elem).Select(x => x.Ind).ToArray();
        int ind = 0;
        var min = a[minInd[q - 1]] - a[minInd[0]];
        while (ind < n)
        {
            //indを取り除かないとしたら
            var splitAt = minInd[ind];
            var section = sections[splitAt];
            
            var lSection = new Section() { Start = section.Start, End = splitAt - 1 };
            var rSection = new Section() { Start = splitAt + 1, End = section.End };

            sections[splitAt] = null;
            for (int i = lSection.Start; i <= lSection.End; i++)
                sections[i] = lSection;
            for (int i = rSection.Start; i <= rSection.End; i++)
                sections[i] = rSection;

            int[] maxOpeartionCount = new int[n];
            for (int i = 0; i < n; i++)
            {
                var elem = sections[i];
                if (elem == null) continue;
                maxOpeartionCount[elem.Start] = elem.GetOperatableCount(k);
                i = elem.End;
            }

            for (int i = ind + 1, count = 0; i < n; i++)
            {
                var sec = sections[minInd[i]];
                if (maxOpeartionCount[sec.Start] <= 0)
                    continue;
                maxOpeartionCount[sec.Start]--;
                count++;
                if (count == q)
                {
                    min = Min(min, a[minInd[i]] - a[minInd[ind + 1]]);
                    break;
                }
            }
            ind++;
        }
        Console.WriteLine(min);
    }
}

class Section
{
    public int Start;
    public int End;
    public int Length => End - Start + 1;
    public int GetOperatableCount(int k) => Max(0, Length - k + 1);
}


class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Propagate(i += LeafCount); Operators[i] = Merge(Operators[i], x); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}
