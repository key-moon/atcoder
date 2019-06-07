// detail: https://atcoder.jp/contests/dp/submissions/5813906
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(double.Parse).ToArray();
        double[] currentProb = new double[n + 1];
        currentProb[0] = 1;
        for (int i = 0; i < a.Length; i++)
        {
            double[] newProb = new double[n + 1];
            newProb[0] = currentProb[0] * (1 - a[i]);
            for (int j = 1; j < currentProb.Length; j++) newProb[j] = currentProb[j - 1] * a[i] + currentProb[j] * (1 - a[i]);
            currentProb = newProb;
        }
        Console.WriteLine(currentProb.Skip((n + 1) / 2).Sum());
    }
}
