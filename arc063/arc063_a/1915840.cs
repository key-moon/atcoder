// detail: https://atcoder.jp/contests/arc063/submissions/1915840
using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        char lastc = s[0];
        int res = 0;
        foreach (var c in s)
        {
            if (c != lastc)
            {
                res++;
                lastc = c;
            }
        }
        Console.WriteLine(res);
    }
}
