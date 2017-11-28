// detail: https://atcoder.jp/contests/joi2011yo/submissions/1814179
using System;
using System.Linq;
class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] i = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        long[][] res = new long[i.Length][];
        long[] restemp = new long[21];
        restemp[i.Last()] = 1;
        res[i.Length - 1] = restemp;
        for (int j = i.Length - 2; j >= 1; j--)
        {
            res[j] = restemp.Select((x, y) => (y - i[j] >= 0 ? res[j + 1][y - i[j]] : 0) + (y + i[j] <= 20 ? res[j + 1][y + i[j]] : 0)).ToArray();
        }
        Console.WriteLine(res[1][i[0]]);
    }
}
