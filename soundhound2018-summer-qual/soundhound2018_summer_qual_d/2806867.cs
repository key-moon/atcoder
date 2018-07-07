// detail: https://atcoder.jp/contests/soundhound2018-summer-qual/submissions/2806867
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        long money = 999999999999999 + 1;
        int[] nmst = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //nとしmでんしゃ
        //u←→v ab
        //両替 全額
        //s => t
        Dijkstra s;
        Dijkstra e;
        //SからTに移動しつつ両替
        //電車は閉鎖されることがないため
        //iから1にかけて、その都市で両替してからどっか行く場合のそれが欲しい
        //1対全、
        //ダイクストラ
        int[][] uvabs = Enumerable.Repeat(0, nmst[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        List<int> f = new List<int>();
        List<int> t = new List<int>();
        List<long> c = new List<long>();
        foreach (var ubab in uvabs)
        {
            f.Add(ubab[0] - 1);
            t.Add(ubab[1] - 1);
            c.Add(ubab[2]);
            t.Add(ubab[0] - 1);
            f.Add(ubab[1] - 1);
            c.Add(ubab[2]);
        }
        s = new Dijkstra(f.ToArray(), t.ToArray(), c.ToArray(), nmst[0], nmst[2] - 1);

        f = new List<int>();
        t = new List<int>();
        c = new List<long>();
        foreach (var ubab in uvabs)
        {
            f.Add(ubab[0] - 1);
            t.Add(ubab[1] - 1);
            c.Add(ubab[3]);
            t.Add(ubab[0] - 1);
            f.Add(ubab[1] - 1);
            c.Add(ubab[3]);
        }
        e = new Dijkstra(f.ToArray(), t.ToArray(), c.ToArray(), nmst[0], nmst[3] - 1);

        List<long> res = new List<long>();
        for (int i = nmst[0] - 1; i >= 0; i--)
        {
            long last = 0;
            if (res.Count != 0) last = res.Last();
            res.Add(Max(money - (s.GetCost(i) + e.GetCost(i)), last));
        }
        Console.WriteLine(string.Join("
", res.ToArray().Reverse()));
    }
}

class Dijkstra
{
    int E;
    Vertex[] point;
    Vertex S;
    public long GetCost(int i)
    {
        return point[i].cost;
    }
    public Dijkstra(int[] f, int[] t, long[] cost, int n, int s)
    {
        point = new Vertex[n];
        for (int i = 0; i < n; i++)
        {
            point[i] = new Vertex();
        }
        E = f.Length;
        for (int i = 0; i < E; i++)
        {
            point[f[i]].AddEdge(point[t[i]], cost[i]);
        }
        S = point[s];
        calc();
    }
    void calc()
    {
        Heap H = new Heap(2 * E + 1);
        S.cost = 0;
        H.push(new Edge(S, 0));
        while (!H.Empty())
        {
            Vertex v = H.pop().v;
            if (v.finished)
            {
                continue;
            }
            v.finished = true;
            for (int i = 0; i < v.edges.Count; i++)
            {
                Vertex vi = v.edges[i];
                if (vi.cost == -1 || vi.cost > v.costs[i] + v.cost)
                {
                    vi.cost = v.costs[i] + v.cost;
                    H.push(new Edge(vi, vi.cost));
                }
            }
        }
    }
}

struct Edge
{
    public Vertex v;
    public long cost;
    public Edge(Vertex v0, long c)
    {
        v = v0;
        cost = c;
    }
}
class Vertex
{
    public bool finished;
    public List<Vertex> edges;
    public List<long> costs;
    public long cost;
    public void AddEdge(Vertex v, long c)
    {
        edges.Add(v);
        costs.Add(c);
    }
    public Vertex()
    {
        edges = new List<Vertex>();
        costs = new List<long>();
        cost = -1;
        finished = false;
    }
}
class Heap
{
    public int size;
    Edge[] obj;
    public Heap(int maxsize)
    {
        size = 0;
        obj = new Edge[maxsize];
    }
    public void push(Edge a)
    {
        int i = size;
        size++;
        while (i > 0)
        {
            int p = (i - 1) / 2;
            if (obj[p].cost <= a.cost)
            {
                obj[i] = a;
                break;
            }
            obj[i] = obj[p];
            i = p;
        }
        if (i == 0)
        {
            obj[0] = a;
        }
    }
    public bool Empty()
    {
        return size == 0;
    }
    public Edge pop()
    {
        Edge t = obj[0];
        int i = 0;
        size--;
        while (2 * i + 1 < size)
        {
            int p = 2 * i + 1;
            if (p + 1 < size && obj[p + 1].cost < obj[p].cost)
            {
                p++;
            }
            if (obj[p].cost < obj[size].cost)
            {
                obj[i] = obj[p];
                i = p;
            }
            else
            {
                obj[i] = obj[size];
                break;
            }
        }
        if (2 * i + 1 >= size)
        {
            obj[i] = obj[size];
        }
        return t;
    }
}
class ReadData
{
    string[] str;
    int counter;
    public ReadData()
    {
        counter = 0;
    }
    public string s()
    {
        if (counter == 0)
        {
            str = Console.ReadLine().Split(' ');
            counter = str.Length;
        }
        counter--;
        return str[str.Length - counter - 1];
    }
    public int i()
    {
        return int.Parse(s());
    }
    public long l()
    {
        return long.Parse(s());
    }
    public double d()
    {
        return double.Parse(s());
    }
    public int[] ia(int N)
    {
        int[] ans = new int[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = i();
        }
        return ans;
    }
    public int[] ia()
    {
        str = Console.ReadLine().Split(' ');
        counter = 0;
        int[] ans = new int[str.Length];
        for (int j = 0; j < str.Length; j++)
        {
            ans[j] = int.Parse(str[j]);
        }
        return ans;
    }
    public long[] la(int N)
    {
        long[] ans = new long[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = l();
        }
        return ans;
    }
    public long[] la()
    {
        str = Console.ReadLine().Split(' ');
        counter = 0;
        long[] ans = new long[str.Length];
        for (int j = 0; j < str.Length; j++)
        {
            ans[j] = long.Parse(str[j]);
        }
        return ans;
    }
    public double[] da(int N)
    {
        double[] ans = new double[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = d();
        }
        return ans;
    }
    public double[] da()
    {
        str = Console.ReadLine().Split(' ');
        counter = 0;
        double[] ans = new double[str.Length];
        for (int j = 0; j < str.Length; j++)
        {
            ans[j] = double.Parse(str[j]);
        }
        return ans;
    }
    public List<int>[] g(int N, int[] f, int[] t)
    {
        List<int>[] ans = new List<int>[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = new List<int>();
        }
        for (int j = 0; j < f.Length; j++)
        {
            ans[f[j]].Add(t[j]);
            ans[t[j]].Add(f[j]);
        }
        return ans;
    }
    public List<int>[] g(int N, int M)
    {
        List<int>[] ans = new List<int>[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = new List<int>();
        }
        for (int j = 0; j < M; j++)
        {
            int f = i() - 1;
            int t = i() - 1;
            ans[f].Add(t);
            ans[t].Add(f);
        }
        return ans;
    }
    public List<int>[] g()
    {
        int N = i();
        int M = i();
        List<int>[] ans = new List<int>[N];
        for (int j = 0; j < N; j++)
        {
            ans[j] = new List<int>();
        }
        for (int j = 0; j < M; j++)
        {
            int f = i() - 1;
            int t = i() - 1;
            ans[f].Add(t);
            ans[t].Add(f);
        }
        return ans;
    }
}
public static class Define
{
    public const long mod = 1000000007;
}
public static class Debug
{
    public static void Print(double[,,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                for (int l = 0; l < k.GetLength(2); l++)
                {
                    Console.Write(k[i, j, l] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    public static void Print(double[,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                Console.Write(k[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void Print(double[] k)
    {
        for (int i = 0; i < k.Length; i++)
        {
            Console.WriteLine(k[i]);
        }
    }
    public static void Print(long[,,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                for (int l = 0; l < k.GetLength(2); l++)
                {
                    Console.Write(k[i, j, l] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    public static void Print(long[,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                Console.Write(k[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void Print(long[] k)
    {
        for (int i = 0; i < k.Length; i++)
        {
            Console.WriteLine(k[i]);
        }
    }
    public static void Print(int[,,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                for (int l = 0; l < k.GetLength(2); l++)
                {
                    Console.Write(k[i, j, l] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    public static void Print(int[,] k)
    {
        for (int i = 0; i < k.GetLength(0); i++)
        {
            for (int j = 0; j < k.GetLength(1); j++)
            {
                Console.Write(k[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void Print(int[] k)
    {
        for (int i = 0; i < k.Length; i++)
        {
            Console.WriteLine(k[i]);
        }
    }
}
