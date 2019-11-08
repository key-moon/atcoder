// detail: https://atcoder.jp/contests/arc031/submissions/8339828
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var map = Enumerable.Repeat(0, 10).Select(_ => Console.ReadLine().Select(x => x == 'o').ToArray()).ToArray();
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (map[i][j]) continue;
                var newmap = DeepCopy(map);
                newmap[i][j] = true;
                if (IsConnected(newmap))
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
        }
        Console.WriteLine("NO");
    }

    static bool[][] DeepCopy(bool[][] map) => map.Select(x => x.ToArray()).ToArray();

    static bool IsConnected(bool[][] map)
    {
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i][j])
                {
                    map[i][j] = false;
                    stack.Push(new Tuple<int, int>(i, j));
                    goto end;
                }
            end:;
        Action<int, int> MoveTo = (y, x) =>
        {
            if (y < 0 || map.Length <= y || x < 0 || map[y].Length <= x || !map[y][x]) return;
            map[y][x] = false;
            stack.Push(new Tuple<int, int>(y, x));
        };
        while (stack.Count > 0)
        {
            var elem = stack.Pop();
            var y = elem.Item1;
            var x = elem.Item2;
            MoveTo(y + 1, x);
            MoveTo(y - 1, x);
            MoveTo(y, x + 1);
            MoveTo(y, x - 1);
        }
        return map.All(x => x.All(y => !y));
    }
}
 
