// detail: https://atcoder.jp/contests/abc149/submissions/9218361
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
        var edges = new int[n - 1][];
        List<int>[] tree = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            edges[i] = st;
            tree[st[0]].Add(st[1]);
            tree[st[1]].Add(st[0]);
        }
        ReRooting<int> subTreeSizes = new ReRooting<int>(n, edges, 0, (x, y) => x + y, x => x + 1);

        ModInt prob = 0;
        for (int i = 0; i < n; i++)
        {
            //白の時、他の部分木の2つ以上に着色があればいい
            //一つ、ゼロの余事象

            ModInt zeroProb = 1 / Power(2, n - 1);
            ModInt oneProb = 0;
            foreach (var subtreeSize in subTreeSizes.dp[i])
            {
                var any = 1 - 1 / Power(2, subtreeSize);
                oneProb += 1 / Power(2, n - subtreeSize - 1) * any;
            }
            prob += 1 - zeroProb - oneProb;
        }
        Console.WriteLine(prob / 2);
    }


    static ModInt Power(ModInt n, long m)
    {
        ModInt pow = n;
        ModInt res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }
}


class ReRooting<T>
{
    public int NodeCount { get; private set; }

    int[][] Neighbours;
    int[][] IndexForNeighbours;

    T[] Res;
    public T[][] dp;

    T IdentityElement;
    Func<T, T, T> Operate;
    Func<T, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identityElement, Func<T, T, T> operate, Func<T, T> operateNode)
    {
        NodeCount = nodeCount;

        IdentityElement = identityElement;
        Operate = operate;
        OperateNode = operateNode;

        List<int>[] neighbours = new List<int>[nodeCount];
        List<int>[] indexForNeighbours = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            neighbours[i] = new List<int>();
            indexForNeighbours[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForNeighbours[edge[0]].Add(neighbours[edge[1]].Count);
            indexForNeighbours[edge[1]].Add(neighbours[edge[0]].Count);
            neighbours[edge[0]].Add(edge[1]);
            neighbours[edge[1]].Add(edge[0]);
        }

        Neighbours = new int[nodeCount][];
        IndexForNeighbours = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Neighbours[i] = neighbours[i].ToArray();
            IndexForNeighbours[i] = indexForNeighbours[i].ToArray();
        }

        dp = new T[Neighbours.Length][];
        Res = new T[Neighbours.Length];

        for (int i = 0; i < Neighbours.Length; i++) dp[i] = new T[Neighbours[i].Length];
        if (NodeCount > 1) Initialize();
        else Res[0] = OperateNode(IdentityElement);
    }

    public T Query(int node) => Res[node];

    private void Initialize()
    {
        int[] parents = new int[NodeCount];
        int[] order = new int[NodeCount];

        #region InitOrderedTree
        var index = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        parents[0] = -1;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            order[index++] = node;
            for (int i = 0; i < Neighbours[node].Length; i++)
            {
                var neighbour = Neighbours[node][i];
                if (neighbour == parents[node]) continue;
                stack.Push(neighbour);
                parents[neighbour] = node;
            }
        }
        #endregion

        #region fromLeaf
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            T accum = IdentityElement;
            int neighbourIndex = -1;
            for (int j = 0; j < Neighbours[node].Length; j++)
            {
                if (Neighbours[node][j] == parent)
                {
                    neighbourIndex = j;
                    continue;
                }
                accum = Operate(accum, dp[node][j]);
            }
            dp[parent][IndexForNeighbours[node][neighbourIndex]] = OperateNode(accum);
        }
        #endregion

        #region toLeaf
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];
            T accum = IdentityElement;
            T[] accumsFromTail = new T[Neighbours[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = IdentityElement;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(dp[node][j], accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                dp[Neighbours[node][j]][IndexForNeighbours[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]));
                accum = Operate(accum, dp[node][j]);
            }
            Res[node] = OperateNode(accum);
        }
        #endregion
    }
}

struct ModInt
{
    const int MOD = 1000000007;
    const long POSITIVIZER = ((long)MOD) << 31;
    long Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator long(ModInt modInt) => modInt.Data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ModInt(long val) => new ModInt(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, int b) => new ModInt() { Data = (a.Data + b + POSITIVIZER) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator +(ModInt a, ModInt b) { long res = a.Data + b.Data; return new ModInt() { Data = res >= MOD ? res - MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, int b) => new ModInt() { Data = (a.Data - b + POSITIVIZER) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator -(ModInt a, ModInt b) { long res = a.Data - b.Data; return new ModInt() { Data = res < 0 ? res + MOD : res }; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % MOD };
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => Data.ToString();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long GetInverse(long a)
    {
        long div, p = MOD, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
        while (true)
        {
            if (p == 1) return x2 + MOD; div = a / p; x1 -= x2 * div; y1 -= y2 * div; a %= p;
            if (a == 1) return x1 + MOD; div = p / a; x2 -= x1 * div; y2 -= y1 * div; p %= a;
        }
    }
}
