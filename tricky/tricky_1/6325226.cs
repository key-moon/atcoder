// detail: https://atcoder.jp/contests/tricky/submissions/6325226
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < t; i++)
        {
            var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            if (ab[0] == long.MinValue && ab[1] == -1)
            {
                builder.AppendLine("9223372036854775808");
            }
            else
            {
                builder.AppendLine((ab[0] / ab[1]).ToString());
            }
        }
        Console.Write(builder.ToString());
    }
}
