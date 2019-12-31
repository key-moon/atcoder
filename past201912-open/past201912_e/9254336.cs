// detail: https://atcoder.jp/contests/past201912-open/submissions/9254336
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        bool[][] hasFollowed = Enumerable.Range(0, n).Select(_ => new bool[n]).ToArray();
        for (int _ = 0; _ < q; _++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 1)
            {
                hasFollowed[query[1] - 1][query[2] - 1] = true;
            }
            if (query[0] == 2)
            {
                for (int i = 0; i < n; i++)
                {
                    if (hasFollowed[i][query[1] - 1]) hasFollowed[query[1] - 1][i] = true;
                }
            }  
            if (query[0] == 3)
            {
                var x = query[1] - 1;
                var initFollow = hasFollowed[x].ToArray();
                for (int i = 0; i < n; i++)
                {
                    if (initFollow[i])
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j != x && hasFollowed[i][j])
                            {
                                hasFollowed[x][j] = true;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(string.Join("
", hasFollowed.Select(x => string.Join("", x.Select(y => y ? "Y" : "N")))));
    }
}
