// detail: https://atcoder.jp/contests/xmascon16midnight/submissions/5876699
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
        for (int i = 0; i < 200; i++) Solve();
    }
    static void Solve()
    {
        int[][] answers = Enumerable.Repeat(0, 30).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        //それぞれの回答の中で最も多い回答を「暫定模範解答」とする
        var tempAnswers = getFrequentAnswers(answers);
        //バカを排除
        answers = answers.Where(x => x.Zip(tempAnswers, (X, Y) => X == Y).Count(X => X) >= 15).ToArray();
        for (int i = 0; i < 3; i++)
        {
            //Console.WriteLine(string.Join(" ", answers.Select(x => x.Zip(tempAnswers, (X, Y) => X == Y).Count(X => X)).OrderBy(x => x)));
            tempAnswers = getFrequentAnswers(answers.Where(x => x.Zip(tempAnswers, (X, Y) => X == Y).Count(X => X) >= 25).ToArray());
        }
        Console.WriteLine(string.Join(" ", tempAnswers));
    }
    static int[] getFrequentAnswers(int[][] answers)
    {
        var sums = answers.Aggregate(Enumerable.Repeat(0, 50).Select(_ => new int[] { 0, 0, 0, 0 }).ToArray(), (x, y) =>
            x.Zip(y, (X, Y) =>
            {
                X[Y]++;
                return X;
            }).ToArray()
        );
        return sums.Select(x =>
        {
            var max = x.Max();
            for (int i = 0; i < x.Length; i++) if (max == x[i]) return i;
            throw new Exception();
        }).ToArray();
    }
}
