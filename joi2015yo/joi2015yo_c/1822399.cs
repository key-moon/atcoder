// detail: https://atcoder.jp/contests/joi2015yo/submissions/1822399
using System;
using System.Linq;
class P
{
    static void Main()
    {
        int[] HW = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        bool[][] m = new bool[HW[0]][].Select(x => Console.ReadLine().Select(y => y == 'c').ToArray()).ToArray();
        for (int i = 0; i < HW[0]; i++)
        {
            bool[] b = m[i];
            int clowd = -1;
            string res = "";
            for (int j = 0; j < HW[1]; j++)
            {
                if (m[i][j]) clowd = 0;
                else if (clowd != -1) clowd++;
                res += clowd + (j < HW[1] - 1 ? " " : "");
            }
            Console.WriteLine(res);
        }
    }
}
