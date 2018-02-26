// detail: https://atcoder.jp/contests/abc001/submissions/2137950
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] dd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] s = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" , "N"};
        double[] lim = { 0.25, 1.55, 3.35, 5.45, 7.95, 10.75, 13.85, 17.15, 20.75, 24.45, 28.45, 32.65, double.MaxValue };
        double windp = dd[1] / 60d;
        int wind = 0;
        for (int i = 0; i < lim.Length; i++)
        {
            if(windp < lim[i])
            {
                wind = i;
                break;
            }
        }
        string dir = wind != 0 ? s[(int)Math.Floor((dd[0] + 112.5) / 225)] : "C";
        Console.WriteLine($"{dir} {wind}");
    }
}
