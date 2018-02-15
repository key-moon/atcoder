// detail: https://atcoder.jp/contests/joi2006yo/submissions/2096160
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
                temp = top;
                top = south;
                south = bottom;
                bottom = north;
                north = temp;
                break;
            case "East":
                temp = top;
                top = west;
                west = bottom;
                bottom = east;
                east = temp;
                break;
            case "West":
                temp = top;
                top = east;
                east = bottom;
                bottom = west;
                west = temp;
                break;
            case "South":
                temp = top;
                top = north;
                north = bottom;
                bottom = south;
                south = temp;
                break;
            case "Right":
                temp = south;
                south = east;
                east = north;
                north = west;
                west = temp;
                break;
            case "Left":
                temp = south;
                south = west;
                west = north;
                north = east;
                east = temp;
                break;
        }
    }
}
