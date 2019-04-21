// detail: https://atcoder.jp/contests/arc086/submissions/5074815
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        //絶対値のmaxの奴を2回足すと
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int max = -1;
        int maxInd = -1;
        for (int i = 0; i < a.Length; i++)
        {
            if (max < Abs(a[i]))
            {
                max = Abs(a[i]);
                maxInd = i;
            }
        }

        List<Tuple<int, int>> ops = new List<Tuple<int, int>>();
        int currentInd = a[maxInd] > 0 ? 0 : n - 1;
        int next = a[maxInd] > 0 ? 1 : -1;
        ops.Add(new Tuple<int, int>(maxInd, currentInd));
        ops.Add(new Tuple<int, int>(maxInd, currentInd));
        currentInd += next;
        while (0 <= currentInd && currentInd < n)
        {
            ops.Add(new Tuple<int, int>(currentInd - next, currentInd));
            ops.Add(new Tuple<int, int>(currentInd - next, currentInd));
            currentInd += next;
        }
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join("
", ops.Select(x => $"{x.Item1 + 1} {x.Item2 + 1}")));
    }
}
