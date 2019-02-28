// detail: https://atcoder.jp/contests/arc029/submissions/4413690
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;


class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
        int h = ab[0];
        int w = ab[1];
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var cd = Console.ReadLine().Split().Select(int.Parse).ToList();
            //90度回転で収まるか
            Console.WriteLine(
                (ab[0] <= cd[0] && ab[1] <= cd[1]) || (ab[1] <= cd[0] && ab[0] <= cd[1]) ||
                Judge(h, w, cd[0], cd[1]) || Judge(h, w, cd[1], cd[0]) || Judge(w, h, cd[0], cd[1]) || Judge(w, h, cd[1], cd[0]) ? "YES" : "NO");
        }
    }

    static bool Judge(double h, double w, double bh, double bw)
    {
        const double EPS = 0.0001;

        if (bh < w) return false;
        //      ↓s′
        //l′|  　／＼
        //→ |　／　／
        // 　|／　／
        //s→|＼／
        //　  ↑l   
        //──────────
        //l = sqrt(w^2 - s^2)です。
        //初期値は対角線が垂直なときで、s : w = w : sqrt(w^2 + h^2)になります。
        double invalid = w * w / Sqrt(h * h + w * w);
        //wが真横の時は、(少なくとも縦には)必ず収まるように上で弾いています。(これすら収まらなかったら論外)
        double valid = w;
        for (int _ = 0; _ < 100; _++)
        {
            var mid = (invalid + valid) / 2;
            //とりあえず高さを収めます 高さはs + l′で、l′= l * (h / w) です(相似なので)
            if (mid + h * Sqrt(w * w - mid * mid) / w <= bh) valid = mid;
            else invalid = mid;
        }
        //幅が収まっているか調べます 幅はl + s′で、s′= s * (h / w) です(相似なので)
        return valid * h / w + Sqrt(w * w - valid * valid) < bw + EPS;
    }
}
