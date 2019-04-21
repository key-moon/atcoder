// detail: https://atcoder.jp/contests/bitflyer2018-final-open/submissions/5078762
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
        string s = Console.ReadLine();
        Stack<int> streakStack = new Stack<int>();
        streakStack.Push(0);
        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                //閉じる前提で足している
                streakStack.Push(0);
            }
            else
            {
                long elem = streakStack.Pop();
                res += elem * (elem + 1) / 2;
                if (streakStack.Count == 0) streakStack.Push(0);
                else streakStack.Push(streakStack.Pop() + 1);
            }
        }
        while (streakStack.Count > 0)
        {
            long elem = streakStack.Pop();
            res += elem * (elem + 1) / 2;
        }
        Console.WriteLine(res);
    }
}
