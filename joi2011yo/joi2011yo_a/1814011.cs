// detail: https://atcoder.jp/contests/joi2011yo/submissions/1814011
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int i = new int[4].Select(x => int.Parse(Console.ReadLine())).Sum();
        Console.WriteLine(i / 60);
        Console.WriteLine(i % 60);
    }
}
