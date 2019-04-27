// detail: https://atcoder.jp/contests/utpc2011/submissions/5133319
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


static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int res = 0;
        if (s.Length % 2 == 1 && s[s.Length / 2] < 'a') res++; 
        for (int i = 0; i < s.Length / 2; i++)
        {
            var center = s[i];
            var back = s[s.Length - i - 1];
            if (!((center ^ back) == 1 || ('a' <= center && center == back))) res++;
        }
        Console.WriteLine(res);
    }
}
