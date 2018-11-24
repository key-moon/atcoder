// detail: https://atcoder.jp/contests/dwacon5th-prelims/submissions/3658269
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
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        Console.ReadLine();
        int[] q = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //D,M,Q,Xに文字を分類し、WMに突っ込む
        int[] ruisekiD = new int[n + 1];
        int[] ruisekiM = new int[n + 1];
        int[] ruisekiC = new int[n + 1];
        List<int> posD = new List<int>();
        List<int> posM = new List<int>();
        List<int> posC = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'D':
                    ruisekiD[i + 1] = ruisekiD[i] + 1;
                    ruisekiM[i + 1] = ruisekiM[i];
                    ruisekiC[i + 1] = ruisekiC[i];
                    posD.Add(i);
                    break;
                case 'M':
                    ruisekiD[i + 1] = ruisekiD[i];
                    ruisekiM[i + 1] = ruisekiM[i] + 1;
                    ruisekiC[i + 1] = ruisekiC[i];
                    posM.Add(i);
                    break;
                case 'C':
                    ruisekiD[i + 1] = ruisekiD[i];
                    ruisekiM[i + 1] = ruisekiM[i];
                    ruisekiC[i + 1] = ruisekiC[i] + 1;
                    posC.Add(i);
                    break;
                default:
                    ruisekiD[i + 1] = ruisekiD[i];
                    ruisekiM[i + 1] = ruisekiM[i];
                    ruisekiC[i + 1] = ruisekiC[i];
                    break;
            }
        }

        //各クエリ毎に舐めていく際のそれを変える?
        //各クエリ毎にD開始で舐める 末尾削除&先頭追加を繰り返しながら舐めていく
        if(posD.Count == 0 || posM.Count== 0|| posC.Count == 0)
        {
            for (int i = 0; i < q.Length; i++) Console.WriteLine(0);
            return;
        }

        for (int qiter = 0; qiter < q.Length; qiter++)
        {
            int currentQuery = q[qiter];

            //cの現在のそれ
            Stack<int> cInds = new Stack<int>();
            long res = 0;
            //現在のDにおいて該当するCについてつくれるMの数
            long currentmCount = 0;
            //現在の区間において存在しているmの数
            long currensectiontmCount = 0;

            /*int ccount = 0;
            for (int i = currentQuery - 1; i >= 0; i--)
            {
                switch (s[i])
                {
                    case 'M':
                        currensectiontmCount++;
                        currentmCount += ccount;
                        break;
                    case 'C':
                        ccount++;
                        break;
                }
            }
            */
            for (int i = 0; i < currentQuery; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        currensectiontmCount++;
                        break;
                    case 'C':
                        cInds.Push(i);
                        currentmCount += currensectiontmCount;
                        break;
                }
            }
            //区間を一つ移動
            for (int i = 0; i < s.Length - 2; i++)
            {
                switch (s[i])
                {
                    case 'D':
                        res += currentmCount;
                        break;
                    case 'M':
                        currentmCount -= cInds.Count;
                        currensectiontmCount--;
                        break;
                    case 'C':
                        cInds.Pop();
                        break;
                }
                if(i + currentQuery < s.Length)
                {
                    switch (s[i + currentQuery])
                    {
                        case 'D':
                            //ケツにD出てきても何もせんでええやろ
                            break;
                        case 'M':
                            currensectiontmCount++;
                            break;
                        case 'C':
                            cInds.Push(i + currentQuery);
                            currentmCount += currensectiontmCount;
                            break;
                    }
                }
            }
            Console.WriteLine(res);
        }
    }
}
