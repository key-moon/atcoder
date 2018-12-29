// detail: https://atcoder.jp/contests/code-festival-2017-quala/submissions/3891573
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i <= nmk[0]; i++)
        {
            for (int j = 0; j <= nmk[1]; j++)
            {
                if (i * j + (nmk[0] - i) * (nmk[1] - j) == nmk[2])
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
        }
        Console.WriteLine("No");
    }
}
