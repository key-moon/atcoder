// detail: https://atcoder.jp/contests/abc072/submissions/1932792
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        //int N = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("",Console.ReadLine().Where((x,y) => y %2 ==0).ToArray()));
    }
}
