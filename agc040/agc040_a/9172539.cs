// detail: https://atcoder.jp/contests/agc040/submissions/9172539
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        string s = Console.ReadLine();
        long sum = 0;
        long last = 0;
        foreach (var match in Regex.Matches(s, ">*<*", RegexOptions.Compiled).Cast<Match>())
        {
            var val = match.Value;
            Debug.WriteLine(val);
            long decr = val.Count(x => x == '>');
            long incr = val.Count(x => x == '<');
            sum += decr * (decr - 1) / 2;
            sum += incr * (incr - 1) / 2;
            sum += Max(decr, last);
            last = incr;
        }
        sum -= last;
        Console.WriteLine(sum);
    }
}
