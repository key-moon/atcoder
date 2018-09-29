// detail: https://atcoder.jp/contests/arc103/submissions/3298087
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        //対称である必要があって、下から攻めてく感じ 10^5なので、えー
        //作ることができないを作りたい
        //HLみたいな感じで木の枝を上一本だと見てあげる
        //端の0からやっていくにはそうしかない ないので
        List<Tuple<int, int>> vectors = new List<Tuple<int, int>>();
        if (s[0] != s[s.Length - 2] || s[0] == '0' || s[s.Length - 1] == '1') goto end;
        vectors.Add(new Tuple<int, int>(1, 2));
        int lastPoint = 2;
        for (int i = 1; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 2]) goto end;
            vectors.Add(new Tuple<int, int>(lastPoint, i + 2));
            if (s[i] == '1') lastPoint = i + 2;
        }
        for (int i = s.Length / 2 + 2; i <= s.Length; i++)
        {
            vectors.Add(new Tuple<int, int>(lastPoint, i));
        }
        Console.WriteLine(string.Join("
", vectors.Select(x => $"{x.Item1} {x.Item2}")));
        return;
        //真ん中の辺みたいなのがあって、そこで2つのシーケンスを繋げるとかしないと駄目
        //全部必要部分は構築したらあとはウニでいいかも?
        end:;
        Console.WriteLine("-1");
    }
}
