// detail: https://atcoder.jp/contests/agc029/submissions/3792683
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        long scount = 0;
        long splace = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'W')
            {
                scount++;
                splace += (i + 1);
            }
        }
        Console.WriteLine(splace - (scount + 1) * scount / 2);
    }
}

class State
{
    string seq;
    int[] remain;
    public State(string seq, int[] remain)
    {
        this.seq = seq;
        this.remain = remain.ToArray();
    }
}
