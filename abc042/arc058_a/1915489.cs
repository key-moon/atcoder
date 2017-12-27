// detail: https://atcoder.jp/contests/abc042/submissions/1915489
using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int N = Console.ReadLine().Split().Select(int.Parse).ToArray()[0];
        string[] D = Console.ReadLine().Split();

        int i = N - 1;
        loopHead:;
        i++;
        string iStr = i.ToString();
        foreach (var d in D) if (iStr.Contains(d.ToString())) goto loopHead;
        Console.WriteLine(i);
    }
}
