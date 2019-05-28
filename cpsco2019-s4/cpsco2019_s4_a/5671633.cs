// detail: https://atcoder.jp/contests/cpsco2019-s4/submissions/5671633
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

static class P
{
    static void Main()
    {
        var lx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int place = 0;
        int dir = 0;
        for (int i = 0; i < lx[1]; i++)
        {
            if (place == lx[0]) dir = -1;
            if (place == 0) dir = 1;
            place += dir;
        }
        Console.WriteLine(place);
    }
}
