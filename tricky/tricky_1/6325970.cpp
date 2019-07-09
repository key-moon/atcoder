// detail: https://atcoder.jp/contests/tricky/submissions/6325970
#include <bits/stdc++.h>
using namespace std;

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#define fseek_unlocked fseek
#endif


int main()
{
    uint32_t n = 0;
    uint64_t a, b, x;
    char f[19]{ };
    int k = getchar_unlocked();
    while ('0' <= k)
    {
        n = n * 10 + k - '0';
        k = getchar_unlocked();
    }
    for (size_t i = 0; i < n; i++)
    {
        bool sign = false;

        a = 0;
        k = getchar_unlocked();
        if (k == '-') { sign ^= true; k = getchar_unlocked(); }
        
        //1
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //2
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //3
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //4
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //5
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //6
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //7
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //8
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //9
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //10
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //11
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //12
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //13
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //14
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //15
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //16
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //17
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //18
        a = a * 10 + k - 48;
        k = getchar_unlocked();
        if (k == ' ') goto readAEnd;
        //19
        a = a * 10 + k - 48;
        k = getchar_unlocked();
    readAEnd:;

        b = 0;
        k = getchar_unlocked();
        if (k == '-') { sign ^= true; k = getchar_unlocked(); }
        //1
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //2
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //3
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //4
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //5
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //6
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //7
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //8
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //9
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //10
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //11
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //12
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //13
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //14
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //15
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //16
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //17
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //18
        b = b * 10 + k - 48;
        k = getchar_unlocked();
        if (k == '
') goto readBEnd;
        //19
        b = b * 10 + k - 48;
        k = getchar_unlocked();
    readBEnd:;

        x = a / b;
        if ((x != 0) && sign) putchar_unlocked('-');
        int s = 0;
        do
        {
            f[s++] = x % 10;
            x /= 10;
        } while (x);
        while (s--)
            putchar_unlocked(f[s] + '0');
        putchar_unlocked('
');
    }
    return 0;
}
