// detail: https://atcoder.jp/contests/code-festival-2017-qualc/submissions/3559069
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;


class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int head = 0;
        int tail = s.Length - 1;
        int res = 0;
        while (true)
        {
            if (head >= tail) break;
            if (s[head] == s[tail])
            {
                head++;
                tail--;
                continue;
            }
            if (s[head] == 'x')
            {
                head++;
                res++;
                continue;
            }
            if(s[tail] == 'x')
            {
                tail--;
                res++;
                continue;
            }
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(res);
    }
}
