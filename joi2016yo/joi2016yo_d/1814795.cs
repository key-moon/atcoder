// detail: https://atcoder.jp/contests/joi2016yo/submissions/1814795
using System;
using System.Linq;
class P
{
    static void Main()
    {
        //←西(west)　(east)東→
        const long random = 1145141919810;
        const int east = 1;
        const int west = 2;
        long[] NTQ = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToArray();
        long[][] People = new long[NTQ[0]][].Select(x => Console.ReadLine().Split(' ').Select(y => long.Parse(y)).ToArray()).ToArray();
        int[] Q = new int[NTQ[2]].Select(x => int.Parse(Console.ReadLine()) - 1).ToArray();
        for (int i = 0; i < NTQ[2]; i++)
        {
            long QDir = People[Q[i]][1];
            long QDest = random;
            if (QDir == east)
            {
                for (int j = Q[i] + 1; j < People.Length; j++)
                {
                    if (People[j][1] != east)
                    {
                        QDest = (People[j - 1][0] / 2) + (People[j][0] / 2);
                        break;
                    }
                }
                if (QDest - People[Q[i]][0] >= NTQ[1] || QDest == random)
                {
                    QDest = People[Q[i]][0] + NTQ[1];
                }
            }
            if (QDir == west)
            {
                for (int j = Q[i] - 1; j >= 0; j--)
                {
                    if (People[j][1] != west)
                    {
                        QDest = (People[j + 1][0] / 2) + (People[j][0] / 2);
                        break;
                    }
                }
                if (People[Q[i]][0] - QDest >= NTQ[1] || QDest == random)
                {
                    QDest = People[Q[i]][0] - NTQ[1];
                }
            }
            Console.WriteLine(QDest);
        }
    }
}
