// detail: https://atcoder.jp/contests/arc052/submissions/1958351
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string res = "";
        foreach (char c in Console.ReadLine())
        {
            if (char.IsDigit(c)) res += c;
        }
        Console.WriteLine(res);
    }
}
