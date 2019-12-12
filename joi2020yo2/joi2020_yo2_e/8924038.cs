// detail: https://atcoder.jp/contests/joi2020yo2/submissions/8924038
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
        var expression = new Expression($"({Console.ReadLine()})");
        var res = expression.Calc();
        switch (Console.Read())
        {
            case 'R':
                Console.WriteLine(res.RCount);
                break;
            case 'S':
                Console.WriteLine(res.SCount);
                break;
            case 'P':
                Console.WriteLine(res.PCount);
                break;
        }
    }
}

class Expression
{
    int Ind;
    string Expr;
    public Expression(string expr)
    {
        Ind = 0;
        Expr = expr;
    }
    public ExpressionResult Calc()
    {
        Ind++;
        ExpressionResult secondRes = new ExpressionResult();
        char bufop = '_';
        ExpressionResult firstRes = Expr[Ind] != '(' ? new ExpressionResult(Expr[Ind++]) : Calc();
        while (Ind < Expr.Length && Expr[Ind] != ')')
        {
            var op = Expr[Ind++];
            var res = Expr[Ind] != '(' ? new ExpressionResult(Expr[Ind++]) : Calc();
            if (op == '*')
            {
                firstRes *= res;
            }
            else
            {
                switch (bufop)
                {
                    case '+':
                        secondRes += firstRes;
                        break;
                    case '-':
                        secondRes -= firstRes;
                        break;
                    case '_':
                        secondRes = firstRes;
                        break;
#if DEBUG
                    default:
                        throw new Exception();
#endif
                }
                bufop = op;
                firstRes = res;
            }
        }
        Ind++;
        switch (bufop)
        {
            case '+':
                return secondRes + firstRes;
            case '-':
                return secondRes - firstRes;
            case '_':
                return firstRes;
            default:
                throw new Exception();
        }

    }
}

struct ExpressionResult
{
    public long RCount;
    public long SCount;
    public long PCount;

    public ExpressionResult(long rCount, long pCount, long sCount)
    {
        RCount = rCount;
        SCount = sCount;
        PCount = pCount;
    }

    public ExpressionResult(char literal)
    {
        RCount = 0;
        SCount = 0;
        PCount = 0;
        switch (literal)
        {
            case 'R':
                RCount++;
                break;
            case 'P':
                PCount++;
                break;
            case 'S':
                SCount++;
                break;
            case '?':
                RCount++;
                PCount++;
                SCount++;
                break;
#if DEBUG
            default:
                throw new Exception();
#endif
        }
    }

    public static ExpressionResult operator +(ExpressionResult l, ExpressionResult r)
    => new ExpressionResult(
            (l.RCount * r.RCount + l.RCount * r.SCount + l.SCount * r.RCount) % 1000000007,
            (l.PCount * r.PCount + l.PCount * r.RCount + l.RCount * r.PCount) % 1000000007,
            (l.SCount * r.SCount + l.SCount * r.PCount + l.PCount * r.SCount) % 1000000007
        );

    public static ExpressionResult operator -(ExpressionResult l, ExpressionResult r)
    => new ExpressionResult(
            (l.RCount * r.RCount + l.RCount * r.PCount + l.PCount * r.RCount) % 1000000007,
            (l.PCount * r.PCount + l.PCount * r.SCount + l.SCount * r.PCount) % 1000000007,
            (l.SCount * r.SCount + l.SCount * r.RCount + l.RCount * r.SCount) % 1000000007
        );

    public static ExpressionResult operator *(ExpressionResult l, ExpressionResult r)
    => new ExpressionResult(
            (l.RCount * r.RCount + l.SCount * r.PCount + l.PCount * r.SCount) % 1000000007,
            (l.PCount * r.PCount + l.RCount * r.SCount + l.SCount * r.RCount) % 1000000007,
            (l.SCount * r.SCount + l.PCount * r.RCount + l.RCount * r.PCount) % 1000000007
        );
}
