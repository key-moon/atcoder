// detail: https://atcoder.jp/contests/abc080/submissions/1826459
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] i = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        Console.WriteLine(Math.Min(i[0] * i[1], i[2]));
    }
}
