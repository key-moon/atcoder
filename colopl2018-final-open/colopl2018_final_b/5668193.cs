// detail: https://atcoder.jp/contests/colopl2018-final-open/submissions/5668193
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

static class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        StringBuilder builder = new StringBuilder();
        Stack<char> ops = new Stack<char>();
        foreach (var c in s)
        {
            if (char.IsDigit(c) || c == '(')
            {
                builder.Append(c);
            }
            else if (c == ')')
            {
                builder.Append(c);
                ops.Pop();
            }
            else if (c == ',')
            {
                builder.Append(ops.Peek());
            }
            else
            {
                ops.Push(c);
            }
        }
        Console.WriteLine(builder.ToString());
    }
}
