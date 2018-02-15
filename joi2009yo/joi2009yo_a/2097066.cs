// detail: https://atcoder.jp/contests/joi2009yo/submissions/2097066
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        TimeSpan tsa = new TimeSpan(a[3], a[4], a[5]) - new TimeSpan(a[0], a[1], a[2]);
        TimeSpan tsb = new TimeSpan(b[3], b[4], b[5]) - new TimeSpan(b[0], b[1], b[2]);
        TimeSpan tsc = new TimeSpan(c[3], c[4], c[5]) - new TimeSpan(c[0], c[1], c[2]);
        Console.WriteLine($"{tsa.Hours} {tsa.Minutes} {tsa.Seconds}");
        Console.WriteLine($"{tsb.Hours} {tsb.Minutes} {tsb.Seconds}");
        Console.WriteLine($"{tsc.Hours} {tsc.Minutes} {tsc.Seconds}");
    }
    
}
