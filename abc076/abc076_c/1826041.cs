// detail: https://atcoder.jp/contests/abc076/submissions/1826041
using System;
using System.Linq;
class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        string r = "";
        bool b;
        if (s.Contains(t)) r = s.Replace('?', 'a');
        for (int i = s.Length - t.Length; i >= 0; i--)
        {
            b = true;
            for (int j = 0; j < t.Length; j++)
            {
                if (!(s[i + j] == '?' || t[j] == s[i + j]))
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                char[] rarray = s.Replace('?', 'a').ToArray();
                for (int j = 0; j < t.Length; j++)
                {
                    rarray[i + j] = t[j];
                }
                r = new string(rarray);
                break;
            }
        }
        if (r == "")
        {
            r = "UNRESTORABLE";
        }
        Console.WriteLine(r);
    }
}
