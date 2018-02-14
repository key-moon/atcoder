// detail: https://atcoder.jp/contests/abc005/submissions/2095481
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray(); 
        Console.ReadLine();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < a.Length; i++)
        {
            queue.Enqueue(a[i]);
        }
        for (int i = 0; i < b.Length; i++)
        {
            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("no");
                    return;
                }
                int q = queue.Dequeue();
                if (q <= b[i] && b[i] - t <= q) break;
            }
        }
        Console.WriteLine("yes");
    }
}
