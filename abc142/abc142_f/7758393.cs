// detail: https://atcoder.jp/contests/abc142/submissions/7758393
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
    public static void Main()
    {
        var n = NextInt;
        var m = NextInt;
        List<int>[] neighbours = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (int i = 0; i < m; i++)
        {
            var a = NextInt - 1;
            var b = NextInt - 1;
            neighbours[b].Add(a);
        }

        Queue<State> queue = new Queue<State>();
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(new State() { Arrived = new ImmutableArray<bool>(n).SetValue(i, true), Route = new ImmutableStack<int>().Push(i) , Current = i });
        }
        
        while (queue.Count > 0)
        {
            var elem = queue.Dequeue();
            foreach (var neighbour in neighbours[elem.Current])
            {
                if (elem.Arrived[neighbour])
                {
                    var curStack = elem.Route;
                    List<int> res = new List<int>() { neighbour + 1 };
                    while (curStack.Top != neighbour)
                    {
                        res.Add(curStack.Top + 1);
                        curStack = curStack.Pop();
                    }
                    Console.WriteLine(res.Count);
                    Console.WriteLine(string.Join("
", res));
                    return;
                }   
                queue.Enqueue(
                    new State()
                    {
                        Arrived = elem.Arrived.SetValue(elem.Current, true),
                        Current = neighbour,
                        Route = elem.Route.Push(neighbour)
                    }
                ); ;
            }
        }
        Console.WriteLine(-1);
    }
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = Console.In.Read();
            int sign = 1;
            while (45 > next || next > 57) next = Console.In.Read();
            if (next == 45) { next = Console.In.Read(); sign = -1; }
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = Console.In.Read();
            }
            return res * sign;
        }
    }
}

class State
{
    public int Current;
    public ImmutableArray<bool> Arrived;
    public ImmutableStack<int> Route;
}

class ImmutableArray<T>
{
    public int Length { get; private set; }
    Node Root;

    private ImmutableArray() { }
    public ImmutableArray(int size)
    {
        Length = size;

        int RootIndex = 1;
        while (RootIndex <= size) RootIndex <<= 1;
        RootIndex >>= 1;

        Root = new Node() { Index = RootIndex - 1 };

        Stack<Node> stack = new Stack<Node>();
        stack.Push(Root);
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            var parentIndex = item.Index;
            var lsb = -(parentIndex + 1) & (parentIndex + 1);
            if (lsb == 1) continue;
            lsb >>= 1;
            var left = new Node() { Index = parentIndex - lsb };
            item.Left = left;
            stack.Push(left);

            if (parentIndex >= Length - 1) continue;
            while (parentIndex + lsb > Length) lsb >>= 1;
            var right = new Node() { Index = parentIndex + lsb };
            item.Right = right;
            stack.Push(right);
        }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return GetValue(index); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableArray<T> SetValue(int index, T value)
    {
        AssertIndex(index);
        Node node = Root.GetCopy();
        var newList = new ImmutableArray<T>() { Root = node, Length = Length };
        while (index != node.Index)
        {
            if (index < node.Index) node = (node.Left = node.Left.GetCopy());
            else node = (node.Right = node.Right.GetCopy());
        }
        node.Value = value;
        return newList;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetValue(int index)
    {
        AssertIndex(index);
        Node node = Root;
        while (index != node.Index)
        {
            if (index < node.Index) node = node.Left;
            else node = node.Right;
        }
        return node.Value;
    }

    private void AssertIndex(int index)
    {
        if (index < 0 || Length <= index) throw new IndexOutOfRangeException();
    }

    class Node
    {
        public int Index;
        public T Value;
        public Node Left;
        public Node Right;
        public Node GetCopy() => new Node() { Index = Index, Value = Value, Left = Left, Right = Right };
        public override string ToString() => Value.ToString();
    }
}


class ImmutableStack<T>
{
    readonly ImmutableStack<T> previousStack;
    public readonly T Top;
    public readonly int Count;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack() : this(null, default(T), 0)  { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ImmutableStack(ImmutableStack<T> prev, T top, int count)
    {
        previousStack = prev;
        Top = top;
        Count = count;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Push(T value) => new ImmutableStack<T>(this, value, Count + 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Pop() => previousStack == null ? null : previousStack;
}
