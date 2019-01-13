// detail: https://atcoder.jp/contests/keyence2019/submissions/4006811
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1];
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (a.Distinct().Count() != n || b.Distinct().Count() != m)
        {
            Console.WriteLine(0);
            return;
        }
        HashSet<int> fixedPos = new HashSet<int>();
        List<int> e = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                //確定ポイントは確定リストに入れて飛ばす
                //全ての点について最大値を
                if(a[i] == b[j])
                {
                    fixedPos.Add(a[i]);
                }
                else
                {
                    e.Add(Min(a[i], b[j]));
                }
            }
        }
        var stack = new Stack<Tuple<int, int>>(e.GroupBy(x => x).Select(x => new Tuple<int, int>(x.Key, x.Count())).OrderBy(x => x.Item1));
        long choices = 0;
        long res = 1;
        Debug.WriteLine(stack.Peek());
        for (int i = n * m; i > 0; i--)
        {
            if (fixedPos.Contains(i)) continue;
            bool flag = true;
            while (stack.Count > 0 && stack.Peek().Item1 >= i)
            {
                var item = stack.Pop();
                var num = item.Item2;
                if(item.Item1 == i)
                {
                    flag = false;
                    res *= num;
                    res %= 1000000007;
                    num--;
                }
                choices += num;
            }
            if (flag)
            {
                if(choices == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                res *= choices;
                res %= 1000000007;
                choices--;
            }
        }
        Console.WriteLine(res);
    }
}


static class Writer
{
    public static void WriteLine<T>(this T item) => Console.WriteLine(item);

    public static void WriteLog<T>(this T item) => Debug.WriteLine(item);
}
