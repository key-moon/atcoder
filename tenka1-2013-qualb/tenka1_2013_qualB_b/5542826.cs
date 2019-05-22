// detail: https://atcoder.jp/contests/tenka1-2013-qualb/submissions/5542826
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] ql = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long size = 0;
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        for (int i = 0; i < ql[0]; i++)
        {
            string[] query = Console.ReadLine().Split();
            int[] num = query.Skip(1).Select(int.Parse).ToArray();
            switch (query[0])
            {
                case "Push":
                    stack.Push(new Tuple<int, int>(num[1], num[0]));
                    size += num[0];
                    if (ql[1] < size)
                    {
                        Console.WriteLine("FULL");
                        return;
                    }
                    break;
                case "Pop":
                    if (size < num[0])
                    {
                        Console.WriteLine("EMPTY");
                        return;
                    }
                    size -= num[0];
                    while (stack.Count > 0)
                    {
                        var elem = stack.Pop();
                        if (elem.Item2 <= num[0])
                        {
                            num[0] -= elem.Item2;
                            continue;
                        }
                        stack.Push(new Tuple<int, int>(elem.Item1, elem.Item2 - num[0]));
                        break;
                    }
                    break;
                case "Top":
                    if (size < 1)
                    {
                        Console.WriteLine("EMPTY");
                        return;
                    }
                    Console.WriteLine(stack.Peek().Item1);
                    break;
                case "Size":
                    Console.WriteLine(size);
                    break;
            }
        }
        Console.WriteLine("SAFE");
    }
}
