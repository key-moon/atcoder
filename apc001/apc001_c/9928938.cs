// detail: https://atcoder.jp/contests/apc001/submissions/9928938
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
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var firstGender = GetGender(0);
        var valid = 0;
        var invalid = n - 1;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (GetGender(mid) == (firstGender ^ mid & 1)) valid = mid;
            else invalid = mid;
        }
        GetGender(invalid);
        throw new Exception();
    }

    static int GetGender(int n)
    {
        Console.WriteLine(n);
        var s = Console.ReadLine();
    
        if (s == "Vacant") Environment.Exit(0);

        if (s == "Male") return 0;
        else return 1;
    }
}
