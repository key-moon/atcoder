// detail: https://atcoder.jp/contests/agc021/submissions/2134272
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        
        int n = int.Parse(Console.ReadLine());
        long[][] plot = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();

        for (long i = 0; i < plot.Length; i++)
        {
            long[] basev = new long[0];
            double lcos = 1;
            double rcos = 1;
            for (long j = 0; j < plot.Length; j++)
            {
                if (i != j)
                {
                    long[] v = vectorminus(plot[i], plot[j]);
                    if (basev.Length == 2)
                    {
                        double vdeg = kakudo(basev, v);
                        //ベクトルがベースの右側だったら(外積がマイナス)
                        if (gaiseki(basev, v) < 0)
                        {
                            //今のtopとなす角を比較
                            if (rcos > vdeg)
                            {
                                //大きかったら代入
                                rcos = vdeg;
                            }
                        }
                        //左だったら
                        else if (gaiseki(basev, v) > 0)
                        {
                            //今のtopとなす角を比較
                            if (lcos > vdeg)
                            {
                                //大きかったら代入
                                lcos = vdeg;
                            }
                        }
                        else
                        {
                            long[] super = new long[] { 17178467375, 778918612 };
                            if ((gaiseki(super, v) < 0 && gaiseki(super, basev) > 0) || (gaiseki(super, v) > 0 && gaiseki(super, basev) < 0))
                            {
                                lcos = -1;
                                rcos = -1;
                            }
                        }
                    }
                    else
                    {
                        //初期化
                        basev = new long[] { v[0], v[1] };
                    }
                }
            }
            
            double deg = Math.Max(Math.PI - (Math.Acos(lcos) + Math.Acos(rcos)), 0);
            Console.WriteLine(deg / (Math.PI * 2));
        }
    }
    static long gaiseki(long[] a, long[] b)
    {
        return a[0] * b[1] - a[1] * b[0];
    }
    static double kakudo(long[] a, long[] b)
    {
        return (a[0] * b[0] + a[1] * b[1]) / (vectorlength(a) * vectorlength(b));
    }
    static double vectorlength(long[] a)
    {
        return Math.Sqrt(a[0] * a[0] + a[1] * a[1]);
    }
    static long[] vectorminus(long[] a, long[] b)
    {
        return new long[] { a[0] - b[0], a[1] - b[1] };
    }
}
