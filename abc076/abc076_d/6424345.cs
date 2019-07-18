// detail: https://atcoder.jp/contests/abc076/submissions/6424345
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var time = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var velocity = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] minSpeed = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        minSpeed[0] = 0;
        minSpeed[n] = 0;

        for (int i = 1; i < velocity.Length; i++)
            minSpeed[i] = Min(velocity[i - 1], velocity[i]);

        for (int i = 1; i < minSpeed.Length; i++)
        {
            minSpeed[i] = Min(minSpeed[i - 1] + time[i - 1], minSpeed[i]);
        }
        for (int i = minSpeed.Length - 2; i >= 0; i--)
        {
            minSpeed[i] = Min(minSpeed[i + 1] + time[i], minSpeed[i]);
        }
        double res = 0;
        for (int i = 0; i < n; i++)
        {
            var speedLimit = velocity[i];
            var sectionTime = time[i];
            var startSpeed = minSpeed[i];
            var endSpeed = minSpeed[i + 1];

            var topSpeed = Min(speedLimit, startSpeed + (double)((endSpeed + sectionTime) - startSpeed) / 2);
            var topStartTime =  topSpeed - startSpeed;
            var topEndTime = sectionTime - (topSpeed - endSpeed);

            res += (startSpeed + topSpeed) * topStartTime / 2;
            res += topSpeed * (topEndTime - topStartTime);
            res += (endSpeed + topSpeed) * (sectionTime - topEndTime) / 2;
        }
        Console.WriteLine(res);
    }
}
