// detail: https://atcoder.jp/contests/abc141/submissions/7520783
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nkq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] score = new int[nkq[0]];
        for (int i = 0; i < nkq[2]; i++)
        {
            score[int.Parse(Console.ReadLine()) - 1]++;
        }
        for (int i = 0; i < nkq[0]; i++)
        {
            Console.WriteLine(nkq[1] <= nkq[2] - score[i] ? "No" : "Yes");
        }
    }
}
