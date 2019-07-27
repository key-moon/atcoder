// detail: https://atcoder.jp/contests/abc135/submissions/6575477
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
        long k = int.Parse(Console.ReadLine());
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool isNegativeX = xy[0] < 0;
        bool isNegativeY = xy[1] < 0;
        long X = Abs(xy[0]);
        long Y = Abs(xy[1]);
        if ((X + Y) % 2 == 1 && k % 2 == 0)
        {
            Console.WriteLine(-1);
            return;
        }
        List<Tuple<long, long>> moves = new List<Tuple<long, long>>();
        //アプローチ diffが2k以下で、かつ偶数のときに2stepでゴールできる
        long currentX = 0;
        long currentY = 0;
        while (!(Abs(Y - currentY) + Abs(X - currentX) <= 2 * k && (Abs(Y - currentY) + Abs(X - currentX)) % 2 == 0))
        {
            long remainMove = k;
            if (currentX < X)
            {
                var move = Min(X - currentX, remainMove);
                currentX += move;
                remainMove -= move;
            }
            currentY += remainMove;
            moves.Add(new Tuple<long, long>(currentX, currentY));
        }
        if (X == currentX && Y == currentY) goto end;
        //調整
        
        var xDiff = Abs(X - currentX);
        var yDiff = Abs(Y - currentY);
        if (xDiff < yDiff)
        {
            var ymove = ((xDiff + yDiff) / 2 - xDiff) * (Y < currentY ? -1 : 1);
            var xmove = k - Abs(ymove);
            moves.Add(new Tuple<long, long>(currentX + xmove, currentY + ymove));
        }
        else
        {
            var xmove = (xDiff + yDiff) / 2 - yDiff;
            var ymove = k - xmove;
            moves.Add(new Tuple<long, long>(currentX + xmove, currentY + ymove));
        }
        moves.Add(new Tuple<long, long>(X, Y));
    end:;
        Console.WriteLine(moves.Count);
        Console.WriteLine(string.Join("
", moves.Select(x => $"{(isNegativeX ? -x.Item1 : x.Item1)} {(isNegativeY ? -x.Item2 : x.Item2)}")));
    }
}
