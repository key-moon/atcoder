// detail: https://atcoder.jp/contests/abc047/submissions/1933007
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] WHN = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int xuplim = WHN[0];
        int xdnlim = 0;
        int yuplim = WHN[1];
        int ydnlim = 0;
        int[][] xyas = new int[WHN[2]][].Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

        foreach (int[] xya in xyas)
        {
            switch (xya[2])
            {
                case 1:
                xdnlim = Math.Max(xdnlim,xya[0]);
                break;
                case 2:
                xuplim = Math.Min(xuplim, xya[0]);
                break;
                case 3:
                ydnlim = Math.Max(ydnlim, xya[1]);
                break;
                case 4:
                yuplim = Math.Min(yuplim, xya[1]);
                break;
            }
        }
        Console.WriteLine(Math.Max((xuplim - xdnlim),0) * Math.Max((yuplim - ydnlim), 0));

    }
}
