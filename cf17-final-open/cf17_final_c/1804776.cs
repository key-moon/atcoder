// detail: https://atcoder.jp/contests/cf17-final-open/submissions/1804776
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] i = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        //被りの振り分け
        Array.Sort(i);
        List<int> j = new List<int>();
        List<int> k = new List<int>();
        j.Add(0);
        k.Add(0);
        for (int a = 0; a < i.Length; a++)
        {
            if (a % 2 == 0)
            {
                j.Add(i[a]);
            }
            else
            {
                k.Add(i[a]);
            }
        }
        int minvalue = 24 - (j.Last() + k.Last());
        for (int a = 0; a < j.Count - 1; a++)
        {
            minvalue = Math.Min(minvalue,Math.Abs(j[a] - j[a + 1]));
        }
        for (int a = 0; a < k.Count - 1; a++)
        {
            minvalue = Math.Min(minvalue, Math.Abs(k[a] - k[a + 1]));
        }
        Console.WriteLine(minvalue);
    }
}
