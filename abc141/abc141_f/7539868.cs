// detail: https://atcoder.jp/contests/abc141/submissions/7539868
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        string s = "1008288677408720767 539403903321871999 1044301017184589821 215886900497862655 504277496111605629 972104334925272829 792625803473366909 972333547668684797 467386965442856573 755861732751878143 1151846447448561405 467257771752201853 683930041385277311 432010719984459389 319104378117934975 611451291444233983 647509226592964607 251832107792119421 827811265410084479 864032478037725181";
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();

        var oddPart = a.Aggregate(0L, (x, y) => x ^ y);
        a = a.Select(x => x - (x & oddPart)).ToArray();
        var maxXor = maxSubsetXOR(a);
        Console.WriteLine(oddPart + maxXor * 2);
    }

    public static string ToBinary(this long x) => Convert.ToString(x, 2).PadLeft(64, '0');

    public static long StupidMaxXor(long[] a)
    {
        long max = 0;
        for (int i = 0; i < (1 << a.Length); i++)
        {
            long res = 0;
            for (int j = 0; j < a.Length; j++)
            {
                if (((i >> j) & 1) == 1) res ^= a[j];
            }
            max = Max(max, res);
        }
        return max;
    }
    public static long maxSubsetXOR(long[] a)
    {
        int index = 0;
        for (int i = 63; i >= 0; i--)
        {
            long maxValue = -1;
            int maxIndex = index;
            for (int j = index; j < a.Length; j++)
            {
                if (((a[j] >> i) & 1) == 1 && a[j] > maxValue)
                {
                    maxValue = a[j];
                    maxIndex = j;
                }
            }
            if (maxValue == -1) continue;

            long temp = a[index];
            a[index] = a[maxIndex];
            a[maxIndex] = temp;
            maxIndex = index;

            for (int j = 0; j < a.Length; j++)
                if (j != maxIndex && ((a[j] >> i) & 1) == 1)
                    a[j] ^= a[maxIndex];
             
            index++;
        }
        return a.Aggregate(0L, (x, y) => x ^ y);
    }
}
