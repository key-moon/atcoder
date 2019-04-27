// detail: https://atcoder.jp/contests/utpc2011/submissions/5133436
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
        int maxLength = 0;
        for (int i = 0; i < (1 << s.Length); i++)
        {
            string substr = "";
            for (int j = 0; j < s.Length; j++) if (((i >> j) & 1) == 1) substr += s[j];
            if (!Regex.IsMatch(substr, @"[\[\{\(\]\}\)]*iwi[\[\{\(\]\}\)]*")) goto end;
            if (substr.Length % 2 == 1 && substr[substr.Length / 2] < 'a') goto end;
            for (int j = 0; j < substr.Length / 2; j++)
            {
                var center = substr[j];
                var back = substr[substr.Length - j - 1];
                if (!((center ^ back) == 1 || (center ^ back) == 6 || ('a' <= center && center <= 'z' && center == back))) goto end;
            }
            //Console.WriteLine(substr);
            maxLength = Max(maxLength, substr.Length);
        end:;
        }
        Console.WriteLine(maxLength);
    }
}
