// detail: https://atcoder.jp/contests/abc076/submissions/1826014
using System;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int r = 1;
        for (int i = 0; i < n; i++)
        {
            r = Math.Min(r * 2,r + k);
        }
        Console.WriteLine(r);
    }
}
