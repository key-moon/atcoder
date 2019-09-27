// detail: https://atcoder.jp/contests/abc141/submissions/7717115
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        int curMaxLength = 0;
        var hash = new RollingHash(s);
        for (int i = 0; i < s.Length; i++)
            for (int j = i; j < s.Length; j++)
                while (curMaxLength < j - i && j + curMaxLength < n && hash.Slice(i, curMaxLength + 1) == hash.Slice(j, curMaxLength + 1)) curMaxLength++;
        Console.WriteLine(curMaxLength);
    }
}

class RollingHash
{
    const ulong MOD1 = 998244353;
    const ulong POSITIVIZER1 = MOD1 << 31;
    static uint Base1;
    static ulong[] powMemo1 = new ulong[500000 + 1];

    static RollingHash()
    {
        Base1 = (uint)new Random().Next(129, int.MaxValue);
        powMemo1[0] = 1;
        for (int i = 1; i < powMemo1.Length; i++)
            powMemo1[i] = (powMemo1[i - 1] * Base1) % MOD1;
    }

    ulong[] hash1;

    public RollingHash(string s)
    {
        hash1 = new ulong[s.Length + 1];
        for (int i = 0; i < s.Length; i++)
            hash1[i + 1] = (hash1[i] * Base1 + s[i]) % MOD1;
    }

    public ulong Slice(int begin, int length)
    {
        return (hash1[begin + length] + POSITIVIZER1 - hash1[begin] * powMemo1[length]) % MOD1;
    }
}
