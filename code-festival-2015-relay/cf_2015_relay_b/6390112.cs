// detail: https://atcoder.jp/contests/code-festival-2015-relay/submissions/6390112
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
        Console.WriteLine(Enumerable.Repeat(0, 10).Aggregate("xxxxxxxxxx".ToArray(), (x, y) => x.Zip(Console.ReadLine(), (X, Y) => X == 'o' || Y == 'o' ? 'o' : 'x').ToArray()).All(x => x == 'o') ? "Yes" : "No");
    }
}
