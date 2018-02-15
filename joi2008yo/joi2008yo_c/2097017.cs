// detail: https://atcoder.jp/contests/joi2008yo/submissions/2097017
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> tarou = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToList();
        List<int> hanako = Enumerable.Range(1, 2 * n).Except(tarou).ToList();

        int ba = 0;
        int tind = 0;
        int hind = 0;

        int ban = 1;
        while (tarou.Count * hanako.Count != 0)
        {
            if (ban == 1)
            {
                if (tind >= tarou.Count)
                {
                    ba = 0;
                    tind = 0;
                    hind = 0;
                    goto end;
                }
                while (tarou[tind] <= ba)
                {
                    tind++;
                    if (tind >= tarou.Count)
                    {
                        ba = 0;
                        tind = 0;
                        hind = 0;
                        goto end;
                    }
                }
                ba = tarou[tind];
                tarou.RemoveAt(tind);
            }
            else
            {
                if (hind >= hanako.Count)
                {
                    ba = 0;
                    tind = 0;
                    hind = 0;
                    goto end;
                }
                while (hanako[hind] <= ba)
                {
                    hind++;
                    if (hind >= hanako.Count)
                    {
                        ba = 0;
                        tind = 0;
                        hind = 0;
                        goto end;
                    }
                }
                ba = hanako[hind];
                hanako.RemoveAt(hind);
            }
            end:;
            ban *= -1;
            //Console.WriteLine($"{ba}
{string.Join(" ",tarou)}
{string.Join(" ",hanako)}

");
        }
        Console.WriteLine($"{hanako.Count}
{tarou.Count}");
    }
}
