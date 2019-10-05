// detail: https://atcoder.jp/contests/agc039/submissions/7875350
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
    static int n;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var matrix = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        int res = 0;
        for (int target = 0; target < n; target++)
        {
            var arrivedStep = new int[n];
            Queue<State> queue = new Queue<State>();
            queue.Enqueue(new State() { Pos = target, Step = 1 });
            arrivedStep[target] = 1;
            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                for (int i = 0; i < n; i++)
                {
                    if (matrix[state.Pos][i] == '0') continue;
                    if (arrivedStep[i] != 0 && (arrivedStep[i] < state.Step - 1 || arrivedStep[i] == state.Step)) goto end;
                    if (arrivedStep[i] != 0) continue;
                    arrivedStep[i] = state.Step + 1;
                    queue.Enqueue(new State() { Pos = i, Step = state.Step + 1 });
                }
            }
            res = Max(res, arrivedStep.Max());
        end:;
        }
        Console.WriteLine(res == 0 ? -1 : res);
    }
}

struct State
{
    public int Pos;
    public int Step;
}
