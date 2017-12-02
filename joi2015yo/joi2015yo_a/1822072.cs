// detail: https://atcoder.jp/contests/joi2015yo/submissions/1822072
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] i = new int[5].Select(x => int.Parse(Console.ReadLine())).ToArray();
        Console.WriteLine(Math.Min(i[0] * i[4], i[4] <= i[2] ? i[1] : i[1] + (i[4] - i[2]) * i[3]));
    }
}
