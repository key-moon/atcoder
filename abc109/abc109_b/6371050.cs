// detail: https://atcoder.jp/contests/abc109/submissions/6371050
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var words = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        Console.WriteLine(words.Zip(words.Skip(1), (x, y) => x.Last() == y.First()).All(x => x) && words.Distinct().Count() == n ? "Yes" : "No");
    }
}
