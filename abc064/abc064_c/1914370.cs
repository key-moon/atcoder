// detail: https://atcoder.jp/contests/abc064/submissions/1914370
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        /*
         */
        Console.ReadLine();
        int[] rates = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] rateColor = new int[8];
        int over3200 = 0;
        foreach (var rate in rates)
        {
            if (rate >= 3200)
            {
                over3200++;
            }
            else
            {
                rateColor[rate / 400] = 1;
            }
        }
        int colorVal = rateColor.Sum();
        Console.WriteLine($"{Math.Max(colorVal, 1)} {colorVal + over3200}");
    }
}
