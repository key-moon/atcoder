// detail: https://atcoder.jp/contests/arc051/submissions/8339939
using System;

public static class P
{
    public static void Main()
    {
        int a = 0;
        int b = 1;
        for (int i = int.Parse(Console.ReadLine()) - 1; i >= 0; i--) { var tmp = b; b = a + b; a = tmp; }
        Console.WriteLine($"{a} {b}");
    }
}
 
