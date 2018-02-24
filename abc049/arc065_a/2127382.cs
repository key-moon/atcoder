// detail: https://atcoder.jp/contests/abc049/submissions/2127382
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int index = 0;

        while (index + 4 < s.Length)
        {
            //dream
            if (s[index] == 'd' && s[index + 1] == 'r' && s[index + 2] == 'e' && s[index + 3] == 'a' && s[index + 4] == 'm')
            {
                index += 5;
                if (index + 1 < s.Length && s[index] == 'e' && s[index + 1] == 'r')
                {
                    if (!(index + 2 < s.Length && s[index + 2] == 'a'))
                    {
                        index += 2;
                    }
                }
            }
            //erase
            else if (s[index] == 'e' && s[index + 1] == 'r' && s[index + 2] == 'a' && s[index + 3] == 's' && s[index + 4] == 'e')
            {
                index += 5;
                if (index < s.Length && s[index] == 'r')
                {
                    index += 1;
                }
            }
            else
            {
                break;
            }
        }
        if (index == s.Length)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
