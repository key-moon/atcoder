// detail: https://atcoder.jp/contests/arc062/submissions/9093326
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
        int n = int.Parse(Console.ReadLine());
        Tile[] tiles = Enumerable.Range(0, n).Select(x =>
        {
            var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new Tile(x, c[0], c[1], c[2], c[3]);
        }).ToArray();
        Dictionary<long, int> tileCounts = new Dictionary<long, int>();
        foreach (var tile in tiles)
        {
            if (!tileCounts.ContainsKey(tile.NormalSeed)) tileCounts.Add(tile.NormalSeed, 0);
            tileCounts[tile.NormalSeed]++;   
        }
        long res = 0;
        foreach (var topTile in tiles)
        {
            var topSeed = topTile.NormalSeed;
            foreach (var bottomTile in tiles.Where(x => x.Num != topTile.Num))
            {
                var bottomSeed = bottomTile.NormalSeed;
                foreach (var rotated in bottomTile.Rotates)
                {
                    //LU  RU
                    //  up
                    //LD  RD

                    //RU  LU
                    //  dn
                    //RD  LD
                    var tile1 = new Tile(0, topTile.RU, topTile.LU, rotated.RU, rotated.LU);
                    var tile2 = new Tile(0, topTile.RD, topTile.RU, rotated.LU, rotated.LD);
                    var tile3 = new Tile(0, topTile.LD, topTile.RD, rotated.LD, rotated.RD);
                    var tile4 = new Tile(0, topTile.LU, topTile.LD, rotated.RD, rotated.RU);
                    var seed1 = tile1.NormalSeed;
                    var seed2 = tile2.NormalSeed;
                    var seed3 = tile3.NormalSeed;
                    var seed4 = tile4.NormalSeed;
                    var count1 = tileCounts.Get(seed1) - (topSeed == seed1 ? 1 : 0) - (bottomSeed == seed1 ? 1 : 0);
                    var count2 = tileCounts.Get(seed2) - (topSeed == seed2 ? 1 : 0) - (bottomSeed == seed2 ? 1 : 0) - (seed1 == seed2 ? 1 : 0);
                    var count3 = tileCounts.Get(seed3) - (topSeed == seed3 ? 1 : 0) - (bottomSeed == seed3 ? 1 : 0) - (seed1 == seed3 ? 1 : 0) - (seed2 == seed3 ? 1 : 0);
                    var count4 = tileCounts.Get(seed4) - (topSeed == seed4 ? 1 : 0) - (bottomSeed == seed4 ? 1 : 0) - (seed1 == seed4 ? 1 : 0) - (seed2 == seed4 ? 1 : 0) - (seed3 == seed4 ? 1 : 0);
                    var perm = (long)count1 * tile1.Order * count2 * tile2.Order * count3 * tile3.Order * count4 * tile4.Order;
                    res += perm;
                }
            }
        }
        res /= 6;
        Console.WriteLine(res);
    }
    static TVal Get<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key) => dict.ContainsKey(key) ? dict[key] : default(TVal);
}

struct Tile
{
    //   0
    // 　↑
    //3←　→1
    //　 ↓
    //   2
    public int Num;
    public int Dir;
    //L←→R
    public int RU;
    public int RD;
    public int LU;
    public int LD;
    public long NormalSeed => Rotates.Min(x => x.ColorSeed);
    public long ColorSeed => GenColorSeed(LU, RU, RD, LD);
    public int Order => (RU == LD && LU == RD ? (RU == LU ? 4 : 2) : 1);
    public IEnumerable<Tile> Rotates
    {
        get
        {
            yield return this;
            var tile = this.Rotate();
            yield return tile;
            tile = tile.Rotate();
            yield return tile;
            tile = tile.Rotate();
            yield return tile;
        }
    }
    public Tile(int num, int lu, int ru, int rd, int ld)
    {
        Num = num;
        Dir = 0;
        RU = ru;
        RD = rd;
        LU = lu;
        LD = ld;
    }
    public Tile Rotate() => new Tile()
    {
        Num = Num,
        Dir = (Dir + 1) & 3,
        RU = RD,
        RD = LD,
        LD = LU,
        LU = RU
    };
    public static long GenColorSeed(int lu, int ru, int rd, int ld) => ((((long)lu * 1000) + ru) * 1000 + rd) * 1000 + ld;
}
