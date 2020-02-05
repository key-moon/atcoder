// detail: https://atcoder.jp/contests/abc047/submissions/9915063
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var whn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] rect = Enumerable.Repeat(0, whn[1]).Select(_ => new bool[whn[0]]).ToArray();

        for (int query = 0; query < whn[2]; query++)
        {
            var xya = Console.ReadLine().Split().Select(int.Parse).ToArray();
            switch (xya[2])
            {
                case 1:
                    for (int y = 0; y < whn[1]; y++)
                        for (int x = 0; x < xya[0]; x++)
                            rect[y][x] |= true;                        
                    break;
                case 2:
                    for (int y = 0; y < whn[1]; y++)
                        for (int x = xya[0]; x < whn[0]; x++)
                            rect[y][x] |= true;
                    break;
                case 3:
                    for (int y = 0; y < xya[1]; y++)
                        for (int x = 0; x < whn[0]; x++)
                            rect[y][x] |= true;
                    break;
                case 4:
                    for (int y = xya[1]; y < whn[1]; y++)
                        for (int x = 0; x < whn[0]; x++)
                            rect[y][x] |= true;
                    break;
            }
        }
        Console.WriteLine(rect.Sum(x => x.Count(y => !y)));
    }
}
