// detail: https://atcoder.jp/contests/abc089/submissions/5448309
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
        var hwd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwd[0];
        var w = hwd[1];
        var d = hwd[2];
        Tuple<int, int>[] nums = new Tuple<int, int>[h * w];
        var a = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                nums[a[i][j]] = new Tuple<int, int>(i, j);
            }
        }
        List<int>[] accumMagic = Enumerable.Repeat(0, d).Select(_ => new List<int>() { 0 }).ToArray();
        for (int i = d; i < nums.Length; i++)
        {
            accumMagic[i % d].Add(accumMagic[i % d].Last() + Abs(nums[i - d].Item1 - nums[i].Item1) + Abs(nums[i - d].Item2 - nums[i].Item2));
        }
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var lr = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            Console.WriteLine(accumMagic[lr[1] % d][lr[1] / d] - accumMagic[lr[0] % d][lr[0] / d]);
        }
    }
}
