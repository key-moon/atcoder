// detail: https://atcoder.jp/contests/abc057/submissions/1912746
using System;

class P
{
    static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        long rootN = Convert.ToInt64(Math.Sqrt(N));
        for (long i = rootN; i >= 1; i--)
        {
            if (N % i == 0)
            {
                int length = Math.Max(i, N / i).ToString().Length;
                Console.WriteLine(length);
                break;
            }
        }
    }
}
