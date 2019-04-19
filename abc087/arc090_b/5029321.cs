// detail: https://atcoder.jp/contests/abc087/submissions/5029321
using System;
using System.IO;
using System.Linq;
using System.Collections;
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
        WeightedUnionFind<long> uf = new WeightedUnionFind<long>(Read(), (x, y) => x + y, x => -x, 0);
        var m = Read();
        for (int i = 0; i < m; i++)
        {
            if (!uf.TryUnite(Read() - 1, Read() - 1, Read()))
            {
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
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


class WeightedUnionFind<T> where T : IEquatable<T>
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    List<int> Sizes;
    List<int> Parent;
    List<T> Value;

    Func<T, T, T> Operate;
    Func<T, T> Inverse;
    T IdentityElement;
    public WeightedUnionFind(int count, Func<T, T, T> operate, Func<T, T> inverse, T identityElement)
    {
        Size = 0;
        GroupCount = 0;
        Parent = new List<int>(count);
        Sizes = new List<int>(count);
        Value = new List<T>(count);
        Operate = operate;
        Inverse = inverse;
        IdentityElement = identityElement;
        ExtendSize(count);
    }

    public bool TryUnite(int x, int y, T distance)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return Operate(distance, Value[y]).Equals(Value[x]);

        GroupCount--;
        if (Sizes[xp] < Sizes[yp])
        {
            Value[xp] = Operate(Operate(Inverse(Value[x]), distance), Value[y]);
            Parent[xp] = yp;
            Sizes[yp] += Sizes[xp];
        }
        else
        {
            Value[yp] = Operate(Operate(Inverse(Value[y]), Inverse(distance)), Value[x]);
            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
        }
        return true;
    }

    public IEnumerable<int> AllRepresents => Parent.Where(x => x == Parent[x]);
    public int GetSize(int x) => Sizes[Find(x)];
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        Stack<int> stack = new Stack<int>();
        while (x != Parent[x])
        {
            stack.Push(x);
            x = Parent[x];
        }
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            Value[elem] = Operate(Value[elem], Value[Parent[elem]]);
            Parent[elem] = x;
        }
        return x;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ExtendSize(int treeSize)
    {
        if (treeSize <= Size) return;
        Parent.Capacity = treeSize;
        Sizes.Capacity = treeSize;
        Value.Capacity = treeSize;
        while (Size < treeSize)
        {
            Parent.Add(Size);
            Sizes.Add(1);
            Value.Add(IdentityElement);
            Size++;
            GroupCount++;
        }
    }
}
