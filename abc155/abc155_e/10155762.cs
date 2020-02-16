// detail: https://atcoder.jp/contests/abc155/submissions/10155762
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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
        int carriedMin = int.MaxValue / 2;
        int uncarriedMin = 0;
        //繰越の次に繰り越す場合
        foreach (var item in Console.ReadLine().Reverse().Select(x => x - '0'))
        {
            var nextCarried = 0;
            var nextUncarried = 0;
            nextCarried = Min(carriedMin + 10 - (item + 1), uncarriedMin + 10 - item);
            nextUncarried = Min(carriedMin + (item + 1), uncarriedMin + item);
            carriedMin = nextCarried;
            uncarriedMin = nextUncarried;
        }
        carriedMin++;
        Console.WriteLine(Min(carriedMin, uncarriedMin));
    }
}
