// detail: https://atcoder.jp/contests/joi2006yo/submissions/2096171
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        dice d = new dice(true);
        int sum = 1;
        for (int i = 0; i < n; i++)
        {
            d.rotate(Console.ReadLine());
            sum += d.top;
        }
        Console.WriteLine(sum);
    }
}
struct dice
{
    public int top;
    public int north;
    public int east;
    public int south;
    public int west;
    public int bottom;
    public dice(bool b)
    {
        top = 1;
        north = 5;
        east = 3;
        south = 2;
        west = 4;
        bottom = 6;
    }
    public void rotate(string dir)
    {
        int temp;
        switch (dir)
        {
            case "North":
                rotate(ref top, ref south, ref bottom, ref north);
                break;
            case "East":
                rotate(ref top, ref west, ref bottom, ref east);
                break;
            case "West":
                rotate(ref top, ref east, ref bottom, ref west);
                break;
            case "South":
                rotate(ref top, ref north, ref bottom, ref south);
                break;
            case "Right":
                rotate(ref south, ref east, ref north, ref west);
                break;
            case "Left":
                rotate(ref south, ref west, ref north, ref east);
                break;
        }
    }
    private void rotate(ref int a,ref int b,ref int c,ref int d)
    {
        int temp;
        temp = a;
        a = b;
        b = c;
        c = d;
        d = temp;
    }
}
