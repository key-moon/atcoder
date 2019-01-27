// detail: https://atcoder.jp/contests/nikkei2019-qual/submissions/4105705
using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Math;
 

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int>[] revedge = Enumerable.Repeat(0, nm[0]).Select(_ => new List<int>()).ToArray();
        List<int>[] edge = Enumerable.Repeat(0, nm[0]).Select(_ => new List<int>()).ToArray();

        int all = nm[0] - 1 + nm[1];
        for (int i = 0; i < all; i++)
        {
            int[] ab =Console.ReadLine().Split().Select(int.Parse).ToArray();
            revedge[ab[1] - 1].Add(ab[0] - 1);
            edge[ab[0] - 1].Add(ab[1] - 1);
        }
        //根の方から確定させていくと強い?
        //BFSした時に一番遅く到達した奴が勝ち
        int root = 0;
        while (revedge[root].Count != 0)
        {
            root = revedge[root][0];
        }
        Debug.WriteLine($"root : {root}");
        int[] updateCount = new int[nm[0]];
        int[] allparents = new int[nm[0]];
        Queue<int> queue = new Queue<int>();
        //距離を振って、長い距離の方を勝たせる
        //枝刈り
        //
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var elem = queue.Dequeue();
            foreach (var child in edge[elem])
            {
                if (child == elem) continue;
                allparents[child] = elem + 1;
                updateCount[child]++;
                if (updateCount[child] < revedge[child].Count) continue;
                queue.Enqueue(child);
            }
        }
        Console.WriteLine(string.Join("
", allparents));
    }
}
