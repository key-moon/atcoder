// detail: https://atcoder.jp/contests/abc062/submissions/1932846
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] N = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string frame = "";
        for (int i = 0; i < N[1] + 2; i++) frame += "#";
        string res = "";
        res += frame;
        res += "
";
        for (int i = 0; i < N[0]; i++)
        {
            res += "#" + Console.ReadLine() + "#
";
        }
        res += frame;
        Console.WriteLine(res);
    }
}
