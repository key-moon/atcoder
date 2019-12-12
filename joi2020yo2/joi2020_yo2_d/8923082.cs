// detail: https://atcoder.jp/contests/joi2020yo2/submissions/8923082
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    static readonly int[][] Transitions =
    {
        new int[]{ 1 },//0
        new int[]{ 0, 2, 4 },//1
        new int[]{ 1, 3, 5 },//2
        new int[]{ 2, 6 },//3
        new int[]{ 1, 5, 7 },//4
        new int[]{ 2, 4, 6, 8 },//5
        new int[]{ 3, 5, 9 },//6
        new int[]{ 4, 8 },//7
        new int[]{ 5, 7, 9 },//8
        new int[]{ 6, 8 },//9
    };
    public static void Main()
    {
        var mr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = mr[0];
        var r = mr[1];
        int[] minSteps = Enumerable.Repeat(int.MaxValue, mr[0] * 10).ToArray();
        Queue<int> queue = new Queue<int>();
        minSteps[0] = 0;
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            var nextStep = minSteps[item] + 1;
            var remain = item / 10;
            var key = item % 10;
            while (true)
            {
                var nextState = ((remain * 10 + key) % m) * 10 + key;
                if (minSteps[nextState] <= nextStep) break;
                minSteps[nextState] = nextStep;
                queue.Enqueue(nextState);
                break;
            }
            foreach (var nextKey in Transitions[key])
            {
                var nextState = remain * 10 + nextKey;
                if (minSteps[nextState] <= nextStep) continue;
                minSteps[nextState] = nextStep;
                queue.Enqueue(nextState);
            }
        }
        Console.WriteLine(Enumerable.Range(r * 10, 10).Select(x => minSteps[x]).Min());
    }
}
