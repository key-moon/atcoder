// detail: https://atcoder.jp/contests/keyence2020/submissions/9577809
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

public static class P
{
    static int res = 0;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        res = int.MaxValue;
        var arr = Enumerable.Repeat(0, n).Select(_ => new Card()).ToList();
        for (int i = 0; i < (1 << n); i++)
        {
            for (int j = 0; j < n; j++)
            {
                var f = (i >> j & 1) == 1;
                arr[j].Sign = f ? b[j] : a[j];
                arr[j].Flipped = f;
            }
            res = Min(res, Solve(arr));
        }
        if (res == int.MaxValue) res = -1;
        Console.WriteLine(res);
    }
    static int Solve(List<Card> arr)
    {
        var sorted = arr.OrderBy(x => x.Sign).ToArray();
        int[] oddCount = new int[51];
        int[] evenCount = new int[51];
        for (int i = 0; i < sorted.Length; i++)
        {
            if ((i & 1) == 0)
                evenCount[sorted[i].Sign]++;
            else
                oddCount[sorted[i].Sign]++;
        }
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i].Flipped ^ ((i & 1) == 1))
            {
                if (--oddCount[arr[i].Sign] < 0) return int.MaxValue;
            }
            else
            {
                if (--evenCount[arr[i].Sign] < 0) return int.MaxValue;
            }
        }
        int step = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            var min = arr.Skip(i).Min(x => x.Sign);
            var minInd = arr.TakeWhile(
                (x, y) => y < i || x.Sign != min || (((y - i) & 1) == 1) != x.Flipped
            ).Count();
            if (minInd == arr.Count) return int.MaxValue; 
            var minElem = arr[minInd];
            arr.RemoveAt(minInd);
            arr.Insert(i, minElem);
            var diff = minInd - i;
            step += diff;
            if ((diff & 1) == 1) arr[i].Flipped ^= true;
            for (int j = i + 1; j <= minInd; j++)
                arr[j].Flipped ^= true;
            if (res <= step) return int.MaxValue;
        }
        return step;
    }
}

class Card
{
    public bool Flipped;
    public int Sign;
    public override string ToString() => $"{Sign} {Flipped}";
}
