// detail: https://atcoder.jp/contests/kupc2013/submissions/6389272
#include <bits/stdc++.h>
using namespace std;

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#define fseek_unlocked fseek
#endif

inline uint32_t read()
{
    uint32_t x = 0;
    int k;
    while (true)
    {
        k = getchar_unlocked();
        if (k < '0') break;
        x = x * 10 + k - '0';
    }
    return x;
}

int main() {
    uint32_t n = 0, q = 0;
    int k = getchar_unlocked();
    do
    {
        n = n * 10 + k - '0';
        k = getchar_unlocked();
    } while (k != ' ');
    k = getchar_unlocked();
    do
    {
        q = q * 10 + k - '0';
        k = getchar_unlocked();
    } while (k != '
');
    char name[30] = "kogakubu10gokan";
    int ptr = 15;
    for (size_t i = 0; i < n; i++)
    {
        uint32_t year = 0;
        k = getchar_unlocked();
        do
        {
            year = year * 10 + k - '0';
            k = getchar_unlocked();
        } while (k != ' ');
        if (q < year) break;
        ptr = 0;
        k = getchar_unlocked();
        do
        {
            name[ptr] = k;
            ptr++;
            k = getchar_unlocked();
        } while (k != '
');
    }
    for (size_t i = 0; i < ptr; i++)
    {
        putchar_unlocked(name[i]);
    }
    putchar_unlocked('
');
}
