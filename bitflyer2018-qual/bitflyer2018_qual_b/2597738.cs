// detail: https://atcoder.jp/contests/bitflyer2018-qual/submissions/2597738
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] abn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string s = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'S':
                    if (abn[0] != 0) abn[0]--;
                    break;
                case 'C':
                    if (abn[1] != 0) abn[1]--;
                    break;
                case 'E':
                    if (abn[0] < abn[1]) abn[1]--;
                    else if (abn[0] == 0 && abn[1] == 0) ;
                    else abn[0]--;
                    break;
            }
        }
        Console.WriteLine(abn[0]);
        Console.WriteLine(abn[1]);
    }
}
