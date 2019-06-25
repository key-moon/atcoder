// detail: https://atcoder.jp/contests/joi2008yo/submissions/6121947
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[,] price = new long[nk[0], nk[0]];
        for (int i = 0; i < nk[0]; i++)
            for (int j = 0; j < nk[0]; j++)
                if (i != j)
                    price[i, j] = long.MaxValue / 4;
        for (int _ = 0; _ < nk[1]; _++)
        {
            var query = Console.ReadLine().Split().Select(long.Parse).ToArray();
            if (query[0] == 1)
            {
                price[query[1] - 1, query[2] - 1] = Min(price[query[1] - 1, query[2] - 1], query[3]);
                price[query[2] - 1, query[1] - 1] = Min(price[query[2] - 1, query[1] - 1], query[3]);
                for (int i = 0; i < nk[0]; i++)
                    for (int j = 0; j < nk[0]; j++)
                        for (int k = 0; k < nk[0]; k++)
                            price[j, k] = Min(price[j, k], price[j, i] + price[i, k]);
            }
            else
            {
                var res = price[query[1] - 1, query[2] - 1];
                if (res == long.MaxValue / 4) res = -1;
                Console.WriteLine(res);
            }
        }
    }
}
