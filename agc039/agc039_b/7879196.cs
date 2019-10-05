// detail: https://atcoder.jp/contests/agc039/submissions/7879196
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    static int n;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = Enumerable.Range(0, n).Select(h => Console.ReadLine().Select((x, w) => h == w ? 0 : x == '1' ? 1 : 1 << 29).ToArray()).ToArray();
        PotentializedUnionFind<bool> puf = new PotentializedUnionFind<bool>(n, (x, y) => x ^ y, x => x, false);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i][j] == 1 && !puf.TryUnite(i, j, true))
                {
                    Console.WriteLine(-1);
                    return;
                }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    matrix[j][k] = Min(matrix[j][k], matrix[j][i] + matrix[i][k]);
        Console.WriteLine(matrix.Max(x => x.Max()) + 1);
    }
}

class PotentializedUnionFind<T> where T : IEquatable<T>
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Value;
    Func<T, T, T> Operate;
    Func<T, T> Inverse;
    T Identity;

    public PotentializedUnionFind(int count, Func<T, T, T> operate, Func<T, T> inverse, T identity)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Value = new T[count];
        for (int i = 0; i < count; i++) { Sizes[Parent[i] = i] = 1; Value[i] = identity; }
        Operate = operate;
        Inverse = inverse;
        Identity = identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y, T distance)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);

        if (yp == xp) return Operate(distance, yd).Equals(xd);

        GroupCount--;
        if (Sizes[xp] < Sizes[yp])
        {
            Value[xp] = Operate(Operate(Inverse(xd), distance), yd);
            Parent[xp] = yp;
            Sizes[yp] += Sizes[xp];
        }
        else
        {
            Value[yp] = Operate(Operate(Inverse(yd), Inverse(distance)), xd);
            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetPotential(int x, int y)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);
        if (yp == xp) return Operate(Inverse(xd), yd);
        else return Identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) { Value[x] = Operate(Value[x], Value[Parent[x]]); Parent[x] = Parent[Parent[x]]; x = Parent[x]; }
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int Find(int x, out T distance)
    {
        distance = Identity;
        while (x != Parent[x])
        {
            Value[x] = Operate(Value[x], Value[Parent[x]]);
            Parent[x] = Parent[Parent[x]];
            distance = Operate(distance, Value[x]);
            x = Parent[x];
        }
        return x;
    }
}
