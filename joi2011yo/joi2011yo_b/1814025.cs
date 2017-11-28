// detail: https://atcoder.jp/contests/joi2011yo/submissions/1814025
using System;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int l = int.Parse(Console.ReadLine());
        int r = 0;
        for (int i = 0; i < l; i++)
        {
            string t = Console.ReadLine();
            if ((t + t.Substring(0, s.Length - 1)).Contains(s)) r++;
        }
        Console.WriteLine(r);
    }
}
