// detail: https://atcoder.jp/contests/maximum-cup-2018/submissions/2312178
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nkl = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][][][] menu = newMenu();
        //0:null
        //1:wa
        //2:yo
        //3:ch
        //4:wa yo
        //5:yo ch
        //6:ch wa
        //7:wa yo ch
        menu[0][0][0][0] = 1;
        for (int i = 0; i < nkl[0]; i++)
        {
            int[][][][] newmenu = newMenu();
            for (int i1 = 0; i1 < 8; i1++)
            {
                for (int i2 = 0; i2 < 8; i2++)
                {
                    for (int i3 = 0; i3 < 8; i3++)
                    {
                        for (int i4 = 0; i4 < 8; i4++)
                        {
                            //次回のメニュー
                            for (int j = 1; j < 8; j++)
                            {
                                int[] c = count(nkl[1], j, i1, i2, i3, i4);
                                if (c.Max() <= nkl[2]) newmenu[j][i1][i2][i3] += menu[i1][i2][i3][i4];
                                newmenu[j][i1][i2][i3] %= 1000000007;
                            }
                        }
                    }
                }
            }
            menu = newmenu;
            //Console.WriteLine(sum(menu));
        }
        Console.WriteLine(sum(menu));
    }
    static int sum(int[][][][] a)
    {
        int res = 0;
        for (int i1 = 0; i1 < 8; i1++)
        {
            for (int i2 = 0; i2 < 8; i2++)
            {
                for (int i3 = 0; i3 < 8; i3++)
                {
                    for (int i4 = 0; i4 < 8; i4++)
                    {
                        res += a[i1][i2][i3][i4];
                        res %= 1000000007;
                    }
                }
            }
        }
        return res;
    }
    static int[] count(int until, params int[] a)
    {
        int[] res = new int[3];
        for (int i = 0; i < until; i++)
        {
            switch (a[i])
            {
                case 1:
                    res[0]++;
                    break;
                case 2:
                    res[1]++;
                    break;
                case 3:
                    res[2]++;
                    break;
                case 4:
                    res[0]++;
                    res[1]++;
                    break;
                case 5:
                    res[1]++;
                    res[2]++;
                    break;
                case 6:
                    res[2]++;
                    res[0]++;
                    break;
                case 7:
                    res[0]++;
                    res[1]++;
                    res[2]++;
                    break;
            }
        }
        return res;
    }
    static int[][][][] newMenu() => 
             Enumerable.Repeat(0, 8).Select(_ =>
             Enumerable.Repeat(0, 8).Select(__ =>
             Enumerable.Repeat(0, 8).Select(___ =>
             Enumerable.Repeat(0, 8).ToArray()).ToArray()).ToArray()).ToArray();
}
