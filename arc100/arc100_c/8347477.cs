// detail: https://atcoder.jp/contests/arc100/submissions/8347477
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    static int[] a;
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Top2[] top = Enumerable.Repeat(0, a.Length).Select(_ => new Top2()).ToArray();

        for (int i = 0; i < a.Length; i++)
        {
            var top2 = new Top2();
            for (int ind = 1; ind <= i; ind <<= 1)
                if ((i & ind) != 0) top[i].Update(top[i - ind]);
            top[i].Update(i);
        }
        int[] res = new int[a.Length];
        for (int i = 1; i < res.Length; i++)
            res[i] = Max(res[i - 1], top[i].First + top[i].Second);

        Console.WriteLine(string.Join("
", res.Skip(1)));
    }

    class Top2
    {
        public int FirstInd = -1;
        public int SecondInd = -1;
        public int First { get { return a[FirstInd]; } }
        public int Second { get { return a[SecondInd]; } }
        public void Update(Top2 another)
        {
            Update(another.FirstInd);
            Update(another.SecondInd);
        }
        public void Update(int ind)
        {
            if (ind == -1 || ind == FirstInd || ind == SecondInd) return;
            if (FirstInd == -1 || First < a[ind])
            {
                SecondInd = FirstInd;
                FirstInd = ind;
            }
            else if (SecondInd == -1 || Second < a[ind])
            {
                SecondInd = ind;
            }
        }
    }
}
