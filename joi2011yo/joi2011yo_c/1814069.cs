// detail: https://atcoder.jp/contests/joi2011yo/submissions/1814069
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        int[] o = new int[l];
        for (int i = 0; i < l; i++)
        {
            int[] H = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            o[i] = ((H[0] + H[1] <= N) ? Math.Min(H[0], H[1]) - 1 : N - Math.Max(H[0], H[1])) % 3 + 1;
        }
        for (int i = 0; i < l; i++) Console.WriteLine(o[i]);
    }
}
