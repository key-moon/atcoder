// detail: https://atcoder.jp/contests/arc024/submissions/10184354
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        if (n < k * 2)
        {
            Console.WriteLine("NO");
            return;
        }
        var s = Console.ReadLine();
        //集合をhash化して持っておく
        //具体的な素数を割り当てて適当に掛ければいいのでは?
        HashSet<HashableSet> sets = new HashSet<HashableSet>();
        int[] currentData = new int[26];
        int[] delayedData = new int[26];
        for (int i = 0; i < k; i++)
        {
            currentData[s[i] - 'a']++;
        }
        for (int i = k; i < k * 2; i++)
        {
            delayedData[s[i - k] - 'a']++;
            currentData[s[i - k] - 'a']--;
            currentData[s[i] - 'a']++;
        }
        Action check = () =>
        {
            sets.Add(new HashableSet(delayedData));
            if (sets.Contains(new HashableSet(currentData)))
            {
                Console.WriteLine("YES");
                Environment.Exit(0);
            }
        };
        check();
        for (int i = k * 2; i < s.Length; i++)
        {
            delayedData[s[i - k - k] - 'a']--;
            delayedData[s[i - k] - 'a']++;
            currentData[s[i - k] - 'a']--;
            currentData[s[i] - 'a']++;
            check();
        }
        Console.WriteLine("NO");
    }
}

class HashableSet
{
    const int Size = 26;
    static readonly long[] KEYPRIMES = new long[Size];
    static HashableSet()
    {
        Random rng = new Random();
        for (int i = 0; i < KEYPRIMES.Length; i++)
        {
            var prime = 0;
            do
            {
                prime = rng.Next();
            } while (IsPrime(prime) && !KEYPRIMES.Contains(prime));
            KEYPRIMES[i] = prime;
        }
    }
    public HashableSet(int[] set)
    {
        set.CopyTo(elem, 0);
    }
    public int[] elem = new int[Size];
    public override int GetHashCode() => (int)(elem.Zip(KEYPRIMES, (x, y) => x * y).Sum() % 1000000007);
    public override bool Equals(object obj) => (obj as HashableSet).elem.Zip(elem, (x, y) => x == y).All(x => x);

    static bool IsPrime(int n)
    {
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0) return true;
        }
        return false;
    }
}
