// detail: https://atcoder.jp/contests/agc008/submissions/9169615
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Action abort = () => { Console.WriteLine("No"); Environment.Exit(0); };
     
        int n = int.Parse(Console.ReadLine());
        var x = Console.ReadLine().Split().Select(y => int.Parse(y) - 1).ToArray();
        Queue<int> remainItem = new Queue<int>();
        int[] res = new int[n * n];
        int ind = 0;
        foreach (var item in x.Select((Index, Item) => new { Item = Item + 1, Index }).OrderBy(y => y.Index))
        {
            for (int i = 0; i < item.Item - 1; i++)
            {
                while (res[ind] != 0) ind++;
                if (item.Index <= ind) abort();
                res[ind] = item.Item;
            }
            res[item.Index] = item.Item;
            for (int i = item.Item; i < n; i++)
                remainItem.Enqueue(item.Item);
        }
        while (remainItem.Count > 0)
        {
            while (res[ind] != 0) ind++;
            var item = remainItem.Dequeue();
            if (ind < x[item - 1]) abort();
            res[ind] = item;
        }
        Console.WriteLine("Yes");
        Console.WriteLine(string.Join(" ", res));
    }
}
