// detail: https://atcoder.jp/contests/joi2006yo/submissions/2096098
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int[] convL = Enumerable.Range(0, 10 + 26 + 26).ToArray();
        for (int i = 0; i < n; i++)
        {
            int[] c = Console.ReadLine().Split().Select(x => ctoi(x[0])).ToArray();
            convL[c[0]] = c[1];
        }
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("", Enumerable.Repeat(0, m).Select(_ => itoc(convL[ctoi(Console.ReadLine()[0])])).ToArray()));
    }
    static char itoc(int i)
    {
        int res = 0;
        if (i <= 9) res = '0' + i;
        else if (i <= 35) res = 'a' + (i - 10);
        else res = 'A' + (i - (10 + 26));
        return char.ConvertFromUtf32(res)[0];
    }
    static int ctoi(char c)
    {
        int res = 0;
        if (char.IsNumber(c)) res = c - '0';
        else if (char.IsLower(c)) res = 10 + c - 'a';
        else res = 10 + 26 + c - 'A';
        return res;
    }

}
