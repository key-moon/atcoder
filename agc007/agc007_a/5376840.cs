// detail: https://atcoder.jp/contests/agc007/submissions/5376840
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Debug = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] map = Enumerable.Repeat(0, hw[0]).Select(_ => Console.ReadLine().ToArray()).ToArray();
        if (map[0][0] == '.') goto invalid;
        map[0][0] = '.';
        int y = 0;
        int x = 0;
        while (x != hw[1] || y != hw[0])
        {
            if (y + 1 < hw[0] && map[y + 1][x] == '#')
            {
                y++;
                map[y][x] = '.';
            }
            else if (x + 1 < hw[1] && map[y][x + 1] == '#')
            {
                x++;
                map[y][x] = '.';
            }
            else
            {
                break;
            }
        }
        if(map.All(a => a.All(b => b == '.')))
        {
            Console.WriteLine("Possible");
            return;
        }
    invalid:;
        Console.WriteLine("Impossible");
    }
}
