// detail: https://atcoder.jp/contests/abc079/submissions/1785784
using System;
using System.Linq;
class P
{
    static void Main()
    {
        var i = Console.ReadLine();
        var j = new int[] { int.Parse(i[0].ToString()), int.Parse(i[1].ToString()), int.Parse(i[2].ToString()), int.Parse(i[3].ToString()) };
        var k = j.Sum();
        if (k == 7) Console.WriteLine($"{j[0]}+{j[1]}+{j[2]}+{j[3]}=7");
        else if (k - 2 * j[3] == 7) Console.WriteLine($"{j[0]}+{j[1]}+{j[2]}-{j[3]}=7");
        else if (k - 2 * j[2] == 7) Console.WriteLine($"{j[0]}+{j[1]}-{j[2]}+{j[3]}=7");
        else if (k - 2 * (j[2] + j[3]) == 7) Console.WriteLine($"{j[0]}+{j[1]}-{j[2]}-{j[3]}=7");
        else if (k - 2 * j[1] == 7) Console.WriteLine($"{j[0]}-{j[1]}+{j[2]}+{j[3]}=7");
        else if (k - 2 * (j[1] + j[3]) == 7) Console.WriteLine($"{j[0]}-{j[1]}+{j[2]}-{j[3]}=7");
        else if (k - 2 * (j[1] + j[2]) == 7) Console.WriteLine($"{j[0]}-{j[1]}-{j[2]}+{j[3]}=7");
        else if (k - 2 * (j[1] + j[2] + j[3]) == 7) Console.WriteLine($"{j[0]}-{j[1]}-{j[2]}-{j[3]}=7");
    }
}
