// detail: https://atcoder.jp/contests/arc102/submissions/3116498
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static readonly List<int> pow2 = new List<int>() { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608 };
    static void Main()
    {
        int l = int.Parse(Console.ReadLine());
        //有向グラフ
        //多重辺あってもいいよ
        //頂点数が20以下
        //辺は60以下
        //パスl個

        //頂点を通る/通らないでbit化してOK
        //つーか0辺とn辺みたいなのを頂点毎に貼るとそれは経路の値が一意に定まる
        //異なるパスを貼る戦略
        //終わりまでの0辺をぴーってするとそこまでの2進数が足される

        bool[] b = Convert.ToString(l, 2).Select(x => x == '1').Reverse().ToArray();

        List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();

        int index = pow2.FindIndex(x => l < x);
        //まずは2進数の基本グラフを貼る これは2^indexを持つ
        for (int i = 0; i < b.Length - 1; i++)
        {
            edges.Add(new Tuple<int, int, int>(i, i + 1, 0));
            edges.Add(new Tuple<int, int, int>(i, i + 1, pow2[i]));
        }
        //最上位以外のbitで1になっているところに対応する辺を貼る 辺の長さは重複しないようにpossibleを作っておく
        int currentHighest = pow2[b.Length - 1] - 1;
        for (int i = 0; i < b.Length - 1; i++)
        {
            if (b[i])
            {
                //辺を貼るのは
                edges.Add(new Tuple<int, int, int>(i, b.Length - 1, currentHighest + 1));
                currentHighest += pow2[i];
            }
        }

        Console.WriteLine($"{b.Length} {edges.Count}");
        foreach (var edge in edges)
        {
            Console.WriteLine($"{edge.Item1 + 1} {edge.Item2 + 1} {edge.Item3}");
        }
    }
}
