// detail: https://atcoder.jp/contests/bcu30-2018/submissions/5104729
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var moves = new Tuple<int, int>[] { new Tuple<int, int>(1, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(0, -1) };
        bool[][] res = Enumerable.Repeat(0, hw[0]).Select(_ => new bool[hw[1]]).ToArray();
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var current = new Tuple<int, int>(xy[0] - 1, xy[1] - 1);
        res[xy[0] - 1][xy[1] - 1] = true;
        while (true)
        {
            var currentHeight = map[current.Item1][current.Item2];
            int minheight = int.MaxValue;
            Tuple<int, int> nextMove = null; 
            foreach (var move in moves)
            {
                if (IsValidMove(current, move, hw[0], hw[1]))
                {
                    var moved = Move(current, move);
                    var height = map[moved.Item1][moved.Item2];
                    if (height < currentHeight && 
                        height < minheight && 
                        !res[moved.Item1][moved.Item2])
                    {
                        minheight = height;
                        nextMove = moved;
                    }
                }
            }
            if (nextMove == null) break;
            res[nextMove.Item1][nextMove.Item2] = true;
            current = nextMove;
        }
        Console.WriteLine(string.Join("
", res.Select(x => string.Join("", x.Select(y => y ? "W" : ".")))));
    }

    static bool IsValidMove(Tuple<int, int> elem, Tuple<int, int> move, int h, int w)
        => 
        (0 <= elem.Item1 + move.Item1) && (elem.Item1 + move.Item1 < h) &&
        (0 <= elem.Item2 + move.Item2) && (elem.Item2 + move.Item2 < w);

    static Tuple<int, int> Move(Tuple<int, int> elem, Tuple<int, int> move) => new Tuple<int, int>(elem.Item1 + move.Item1, elem.Item2 + move.Item2);
}
