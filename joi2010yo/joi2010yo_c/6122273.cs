// detail: https://atcoder.jp/contests/joi2010yo/submissions/6122273
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
        var n = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());
        var friendships = Enumerable.Repeat(0, m).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var friendsOfMe = friendships.Where(x => x[0] == 1).Select(x => x[1]).ToArray();
        Console.WriteLine(friendships.Where(x => friendsOfMe.Contains(x[0]) || friendsOfMe.Contains(x[1])).SelectMany(x => x).Distinct().Count() - 1);
    }
}
