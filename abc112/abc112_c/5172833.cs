// detail: https://atcoder.jp/contests/abc112/submissions/5172833
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var xyh = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int cx = 0; cx <= 100; cx++)
        {
            for (int cy = 0; cy <= 100; cy++)
            {
                int hmax = int.MaxValue;
                int h = -1;
                foreach (var item in xyh)
                {
                    var dist = Abs(item[0] - cx) + Abs(item[1] - cy);
                    if(item[2] == 0) hmax = Min(hmax, dist);
                    else
                    {
                        if (h == -1) h = dist + item[2];
                        else if (h != dist + item[2]) goto end;
                    }
                }
                if (h > hmax || hmax < 1) goto end;
                if (h == -1) h = hmax;
                Console.WriteLine($"{cx} {cy} {h}");
                return;
            end:;
            }
        }
    }
}
