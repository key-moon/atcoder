// detail: https://atcoder.jp/contests/abc002/submissions/1945422
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] xyxyxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((double)Math.Abs((xyxyxy[2] - xyxyxy[0]) * (xyxyxy[5] - xyxyxy[1]) - (xyxyxy[4] - xyxyxy[0]) * (xyxyxy[3] - xyxyxy[1]))/2);
    }
}
