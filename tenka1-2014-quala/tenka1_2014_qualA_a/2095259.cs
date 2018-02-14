// detail: https://atcoder.jp/contests/tenka1-2014-quala/submissions/2095259
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("
", Enumerable.Range(1, 1000).Select(x => x.ToString()).OrderBy(x => x).ToArray()));
    }
}
