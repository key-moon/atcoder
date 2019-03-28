// detail: https://atcoder.jp/contests/bitflyer2018-final-open/submissions/4743732
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        Stack<long> stack = new Stack<long>();
        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == ')')
            {
                if (stack.Count == 0) continue;
                long elem = stack.Pop();
                res += elem * (elem + 1) / 2;
                stack.Push((stack.Count != 0 ? stack.Pop() : 0) + 1);
            }
            else
            {
                stack.Push(0);
            }
        }
        
        while (stack.Count > 0)
        {
            long elem = stack.Pop();
            res += elem * (elem + 1) / 2;
        }
        Console.WriteLine(res);
    }
}
