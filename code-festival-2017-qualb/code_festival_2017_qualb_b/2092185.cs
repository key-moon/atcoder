// detail: https://atcoder.jp/contests/code-festival-2017-qualb/submissions/2092185
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int[] d = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < d.Length; i++)
        {
            if (dict.ContainsKey(d[i])) dict[d[i]]++;
            else dict.Add(d[i],1);
        }
        Console.ReadLine();
        int[] t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < t.Length; i++)
        {
            if(!dict.ContainsKey(t[i]) || --dict[t[i]] < 0)
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine("YES");
    }
}
