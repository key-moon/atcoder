// detail: https://atcoder.jp/contests/abc006/submissions/2095538
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int mod = nm[1] % nm[0];
        switch (nm[1] / nm[0])
        {
            case 2:
                Console.WriteLine($"{nm[0] - mod} {mod} 0");
                return;
            case 3:
                Console.WriteLine($"0 {nm[0] - mod} {mod}");
                return;
            case 4:
                if (mod == 0)
                {
                    Console.WriteLine($"0 0 {nm[0]}");
                    return;
                }
                break;
        }
        Console.WriteLine("-1 -1 -1");
    }
}
