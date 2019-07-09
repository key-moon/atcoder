// detail: https://atcoder.jp/contests/tricky/submissions/6326034
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
    do
    {
        n = n * 10 + k - '0';
        k = getchar_unlocked();
    } while ('0' <= k);
    for (size_t i = 0; i < n; i++)
    {
        bool sign = false;

        a = 0;
        k = getchar_unlocked();
        if (k == '-') { k = getchar_unlocked(); sign ^= true; }
        do
        {
            a = a * 10 + k - 48;
            k = getchar_unlocked();
        } while (k != ' ');

        b = 0;
        k = getchar_unlocked();
        if (k == '-') { k = getchar_unlocked(); sign ^= true; }
        do
        {
            b = b * 10 + k - 48;
            k = getchar_unlocked();
        } while (k != '
');

        if (sign && (a >= b)) putchar_unlocked('-');
        x = a / b;
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
