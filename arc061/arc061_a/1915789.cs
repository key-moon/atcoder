// detail: https://atcoder.jp/contests/arc061/submissions/1915789
using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] s = Console.ReadLine().Select(x => x - '0').ToArray();

        long res = 0;
        int max = Convert.ToInt32(Math.Pow(2, s.Length - 1));
        for (int i = 0; i < max; i++)
        {
            bool[] bitmask = Convert.ToString(i, 2).PadLeft(s.Length - 1, '0').Select(x => x == '1').ToArray();
            long num = s[0];
            for (int j = 1; j < s.Length; j++)
            {
                if (bitmask[j - 1])
                {
                    res += num;
                    num = s[j];
                }
                else
                {
                    num = num * 10 + s[j];
                }
            }
            res += num;
        }
        Console.WriteLine(res);
    }
}
