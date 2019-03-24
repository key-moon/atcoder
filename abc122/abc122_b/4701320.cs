// detail: https://atcoder.jp/contests/abc122/submissions/4701320
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
        string s = Console.ReadLine();
        var max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            try
            {
                int length = 0;
                while (true)
                {
                    var sub = s.Substring(i, length);
                    if (sub.Except(new char[] { 'A', 'T', 'G', 'C' }).Count() > 0) break;
                    max = Max(max, length);
                    length++;
                }
            }
            catch { }
        }
        Console.WriteLine(max);
    }
}
