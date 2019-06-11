// detail: https://atcoder.jp/contests/xmascon16midnight/submissions/5876348
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var X = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var dict = X.OrderBy(x => x).Select((item, index) => new { item, index }).ToDictionary(x => x.item, x => x.index);
        List<Tuple<int, int>> firstOp = new List<Tuple<int, int>>();
        List<Tuple<int, int>> secondOp = new List<Tuple<int, int>>();
        bool[] arrived = new bool[n];
        for (int i = 0; i < X.Length; i++)
        {
            if (arrived[i]) continue;
            arrived[i] = true;
            List<int> circuit = new List<int>();
            circuit.Add(i);
            while (true)
            {
                var next = dict[X[circuit.Last()]];
                if (next == i) break;
                arrived[next] = true;
                circuit.Add(next);
            }
            for (int j = 0; j < circuit.Count / 2; j++)
            {
                var item = circuit[j];
                var pair = circuit[circuit.Count - j - 1];
                firstOp.Add(new Tuple<int, int>(item, pair));
            }
            for (int j = 0; j < (circuit.Count - 1) / 2; j++)
            {
                var item = circuit[j + 1];
                var pair = circuit[circuit.Count - j - 1];
                secondOp.Add(new Tuple<int, int>(item, pair));
            }
        }
        if (firstOp.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if(secondOp.Count == 0)
        {
            Console.WriteLine(1);
            Console.Write($"{firstOp.Count} ");
            Console.WriteLine(string.Join(" ", firstOp.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
        }
        else
        {
            Console.WriteLine(2);
            Console.Write($"{firstOp.Count} ");
            Console.WriteLine(string.Join(" ", firstOp.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
            Console.Write($"{secondOp.Count} ");
            Console.WriteLine(string.Join(" ", secondOp.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
        }
    }
}
