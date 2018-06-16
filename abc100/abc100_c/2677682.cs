// detail: https://atcoder.jp/contests/abc100/submissions/2677682
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        List<int> intpow = new List<int>{ 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 };
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        for (int i = 0; i < a.Length; i++)
        {
            for (int j= intpow.Count - 1; j >= 0; j--)
            {
                if(a[i] % intpow[j] == 0)
                {
                    res += j;
                    break;
                }
            }
        }
        Console.WriteLine(res);
    }
    
}
