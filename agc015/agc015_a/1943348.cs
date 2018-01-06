// detail: https://atcoder.jp/contests/agc015/submissions/1943348
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] NAB = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long maxsum = NAB[2] * (NAB[0] - 1) + NAB[1];
        long minsum = NAB[1] * (NAB[0] - 1) + NAB[2];
        if (NAB[0] == 1)
        {
            if (NAB[1] == NAB[2])
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        else if (NAB[1] > NAB[2]) Console.WriteLine(0);
        else
        {
            Console.WriteLine(maxsum - minsum + 1);
        }
    }
}
