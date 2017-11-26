// detail: https://atcoder.jp/contests/cf17-relay-open/submissions/1809932
using System;
using System.Linq;
class P
{
    static void Main()
    {
        var i = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
        var d = i[1] - i[2];
        long c;
        if (i[0] <= i[1]) c = 1;
        else if (d <= 0) c = -1;
        else c = (((i[0] - i[1]) / d) + ((i[0] - i[1]) % d != 0 ? 1 : 0)) * 2 + 1;
        Console.WriteLine(c);
    }
}
