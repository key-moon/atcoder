// detail: https://atcoder.jp/contests/maximum-cup-2018/submissions/2311168
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] map =  Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();
        bool[][][][] isRooted = Enumerable.Repeat(0, 20).Select(_ => Enumerable.Repeat(0, 20).Select(__ => Enumerable.Repeat(0, 20).Select(___ => new bool[20]).ToArray()).ToArray()).ToArray();
        Queue<State> queue = new Queue<State>();
        queue.Enqueue(new State(new Point(1, 1), 2, ab[0], ab[1]));
        while (queue.Count != 0)
        {
            State current = queue.Dequeue();
            List<State> list = new List<State>();
            //右側を振り落とす→左に向きを変える→Decr
            if (current.A != 0)
            {
                State news = current;
                news.A--;
                news.Dir = (4 + news.Dir - 1) % 4;
                list.Add(news);
            }
            if (current.B != 0)
            {
                State news = current;
                news.B--;
                news.Dir = (news.Dir + 1) % 4;
                list.Add(news);
            }
            list.Add(current);
            foreach (var item in list)
            {
                item.Move();
                if(item.Pos.x == hw[1] - 2 && item.Pos.y == hw[0] - 2 && item.A == 0 && item.B == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
                if(map[item.Pos.y][item.Pos.x] != '#' && !isRooted[item.Pos.y][item.Pos.x][item.A][item.B])
                {
                    isRooted[item.Pos.y][item.Pos.x][item.A][item.B] = true;
                    queue.Enqueue(item);
                }
            }
        }
        Console.WriteLine("No");
    }
}
struct State
{
    public Point Pos;
    //0:↑ 1:→ 2:↓ 3:←
    public int Dir;
    public int A;
    public int B;
    public State(Point pos,int dir,int a,int b)
    {
        Pos = pos;
        Dir = dir;
        A = a;
        B = b;
    }
    public void Move()
    {
        switch (Dir)
        {
            case 0:
                Pos.y--;
                break;
            case 1:
                Pos.x++;
                break;
            case 2:
                Pos.y++;
                break;
            case 3:
                Pos.x--;
                break;
        }
    }
}
struct Point
{
    public int x;
    public int y;
    public Point(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}
