// detail: https://atcoder.jp/contests/xmascon18/submissions/6118102
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static Random rng = new Random();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> middles = Enumerable.Repeat(0, n - 1).Select(_ => GetValidPlace()).ToList();
        middles.Add(0);
        if (middles.Distinct().Count() != n) throw new Exception();
        List<Line> lines = new List<Line>();
        HashSet<Vector> vectors = new HashSet<Vector>();
        foreach (var item in middles)
        {

            Line[] newlines = new Line[4];
            while (true)
            {
                int gap1 = GetRandWithRange(100) * 2;
                int gap2 = GetRandWithRange(100) * 2;
                Vector a = new Vector(item - 2, 926326185 + gap1);
                Vector b = new Vector(-item - 1, -926326185 - gap2);
                Vector c = new Vector(item, 926326185 + gap1);
                Vector d = new Vector(-item + 1, -926326185 - gap2);
                Vector e = new Vector(item + 2, 926326185 + gap1);
                newlines[0] = new Line(a, b);
                newlines[1] = new Line(b, c);
                newlines[2] = new Line(c, d);
                newlines[3] = new Line(d, e);

                var count = lines.SelectMany(_ => newlines, (x, y) => Line.Cross(x, y)).Distinct().Count();
                if (count == 4 * lines.Count)
                {
                    break;
                }
                else
                {
                    Debug.WriteLine("hoge");
                }
            }
            lines.AddRange(newlines);
            Console.WriteLine($"{newlines[0]} {newlines[2]} {newlines[3].b}");
        }
    }

    static bool GetRandBool() => rng.NextDouble() < 0.5;
    static int GetValidPlace() => (GetRandBool() ? -1 : 1) * ((int)Floor((1e2 - 2) * rng.NextDouble() * 1e6) + GetRandWithRange(1));
    static int GetRandWithRange(int range) => (int)((GetRandBool() ? -1 : 1) * (range * rng.NextDouble()));
}

class VComp : IEqualityComparer<Vector>
{
    public bool Equals(Vector x, Vector y) => x == y;

    public int GetHashCode(Vector obj) => obj.GetHashCode();
}

struct Line
{
    public Vector a;
    public Vector b;
    public Line(Vector a, Vector b)
    {
        this.a = a;
        this.b = b;
    }

    /// <summary>二直線が交わる点</summary>
    public static Vector Cross(Line a, Line b)
    {
        double delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        if (delta == 0) throw new Exception();
        double ramda = ((b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y)) / delta;
        double mu = ((a.b.x - a.a.x) * (b.b.y - a.a.y) - (a.b.y - a.a.y) * (b.b.x - a.a.x)) / delta;

        return new Vector(a.a.x + ramda * (a.b.x - a.a.x), a.a.y + ramda * (a.b.y - a.a.y));
    }

    public override string ToString() => $"{a} {b}";
}
struct Vector
{
    public double x;
    public double y;
    public double this[int index]
    {
        get
        {
            if (index == 0) return x;
            else return y;
        }
        set
        {
            if (index == 0) x = value;
            else y = value;
        }
    }
    public double Length
    {
        get
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>回転</summary>
    public Vector rotateVector(double radian)
    {
        return new Vector(x * Math.Cos(radian) - y * Math.Sin(radian), x * Math.Sin(radian) + y * Math.Cos(radian));
    }
    /// <summary>長さ</summary>
    #region static

    /// <summary>外積</summary>
    static public double crossProduct(Vector a, Vector b)
    {
        return a.x * b.y - a.y * b.x;
    }
    /// <summary>内積</summary>
    static public double innerProduct(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y;
    }
    #endregion

    #region operator
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.x - b.x, a.y - b.y);
    }

    public static bool operator ==(Vector a, Vector b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(Vector a, Vector b) => a.x != b.x || a.y != b.y;
    #endregion

    public override bool Equals(object obj) => this == (Vector)obj;
    public override int GetHashCode() => (x.GetHashCode() * 11192916 + y.GetHashCode());
    
    public override string ToString() => $"{x} {y}";
}
