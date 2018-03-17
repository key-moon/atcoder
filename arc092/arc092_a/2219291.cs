// detail: https://atcoder.jp/contests/arc092/submissions/2219291
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] red = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        int[][] blue = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        //R,Bは一行2つ以上存在しない
        //それぞれの軸ごとに見て貪欲に取っていく
        //一番xが小さい青について見る
        //xについてはどこでもいいので、yが一番小さい奴を選ぶ
        //x以下で一番yが小さい赤を取る

        //一行に2つない制約を活かしたい
        //
        bool[] redIsUsed = new bool[red.Length];
        bool[] blueIsUsed = new bool[blue.Length];
        for (int i = 0; i < blue.Length; i++)
        {
            int[] minblue = blue[i];
            int maxRedy = -1;
            int minRedInd = -1;
            for (int j = 0; j < red.Length; j++)
            {
                if (!redIsUsed[j] && red[j][0] < minblue[0] && red[j][1] < minblue[1] && maxRedy < red[j][1])
                {
                    maxRedy = red[j][1];
                    minRedInd = j;
                }   
            }
            if (minRedInd != -1)
            {
                blueIsUsed[i] = true;
                redIsUsed[minRedInd] = true;
            }
        }
        Console.WriteLine(redIsUsed.Count(x => x));
    }
}
