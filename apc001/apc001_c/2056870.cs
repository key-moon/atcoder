// detail: https://atcoder.jp/contests/apc001/submissions/2056870
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sectionBegin = 0;
        int sectionEnd = n - 1;
        int lastSex = readSex(0);
        while (true)
        {
            int count = sectionEnd - sectionBegin + 1;
            if(count == 3)
            {
                if ((readSex(sectionBegin + 1) == 0)) return;
                if ((readSex(sectionBegin + 2) == 0)) return;
            }
            else
            {
                //Console.WriteLine($"{sectionBegin} {sectionEnd}");
                int halfPoint = (sectionBegin + sectionEnd) / 2 + ((count / 2) % 2 == 0 ? 0 : 1);
                int sex = readSex(halfPoint);
                if (sex == 0) return;
                //前のグループ
                if (lastSex != sex)
                {
                    sectionEnd = halfPoint;
                    //Console.WriteLine("S");
                }
                //後のグループ
                else
                {
                    sectionBegin = halfPoint;
                    lastSex = sex;
                    //Console.WriteLine("M");
                }
            }
        }
    }
    static int readSex(int i)
    {
        Console.WriteLine(i);
        switch (Console.ReadLine())
        {
            case "Male":
                return 1;
            case "Female":
                return -1;
        }
        return 0;
    }
}
