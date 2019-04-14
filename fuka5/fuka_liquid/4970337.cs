// detail: https://atcoder.jp/contests/fuka5/submissions/4970337
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        while (true)
        {
            var whp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (whp[0] == 0) return;
            var map = Enumerable.Repeat(0, whp[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

            var arrived = new HashSet<Tuple<int, int>>();
            var stack = new Stack<Tuple<int, int>>();
            for (int i = 0; i < whp[2]; i++)
            {
                var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var pos = new Tuple<int, int>(query[1], query[0]);
                if (!arrived.Add(pos)) continue; 
                stack.Push(pos);
                while (stack.Count > 0)
                {
                    var elem = stack.Pop();
                    var height = map[elem.Item1][elem.Item2];
                    if (elem.Item1 > 0 && !arrived.Contains(new Tuple<int, int>(elem.Item1 - 1, elem.Item2)) && map[elem.Item1 - 1][elem.Item2] < height)
                    {
                        var next = new Tuple<int, int>(elem.Item1 - 1, elem.Item2);
                        stack.Push(next);
                        arrived.Add(next);
                    }
                    if (elem.Item1 < whp[1] - 1 && !arrived.Contains(new Tuple<int, int>(elem.Item1 + 1, elem.Item2)) && map[elem.Item1 + 1][elem.Item2] < height)
                    {
                        var next = new Tuple<int, int>(elem.Item1 + 1, elem.Item2);
                        stack.Push(next);
                        arrived.Add(next);
                    }
                    if (elem.Item2 > 0 && !arrived.Contains(new Tuple<int, int>(elem.Item1, elem.Item2 - 1)) && map[elem.Item1][elem.Item2 - 1] < height)
                    {
                        var next = new Tuple<int, int>(elem.Item1, elem.Item2 - 1);
                        stack.Push(next);
                        arrived.Add(next);
                    }
                    if (elem.Item2 < whp[0] - 1 && !arrived.Contains(new Tuple<int, int>(elem.Item1, elem.Item2 + 1)) && map[elem.Item1][elem.Item2 + 1] < height)
                    {
                        var next = new Tuple<int, int>(elem.Item1, elem.Item2 + 1);
                        stack.Push(next);
                        arrived.Add(next);
                    }
                }
            }
            Console.WriteLine(arrived.Count);
        }
    }
}
