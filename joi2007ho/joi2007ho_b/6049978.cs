// detail: https://atcoder.jp/contests/joi2007ho/submissions/6049978
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
        var nk = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var cards = Enumerable.Repeat(0, k).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();
        var hasEmpty = cards[0] == 0;
        var maxLength = 0;
        var currentLength = 0;
        var currentLengthWithEmpty = 0;
        var last = -1;
        for (int i = hasEmpty ? 1 : 0; i < cards.Length; i++)
        {
            if (cards[i] - last > 1)
            {
                if (cards[i] - last == 2)
                {
                    currentLengthWithEmpty = currentLength + 1;
                    currentLength = 0;
                }
                else
                {
                    currentLengthWithEmpty = 1;
                    currentLength = 0;
                }
            }
            currentLength++;
            currentLengthWithEmpty++;
            maxLength = Max(maxLength, hasEmpty ? currentLengthWithEmpty : currentLength);
            last = cards[i];
        }
        Console.WriteLine(maxLength);
    }
}
