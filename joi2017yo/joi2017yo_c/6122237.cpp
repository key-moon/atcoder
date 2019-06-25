// detail: https://atcoder.jp/contests/joi2017yo/submissions/6122237
#include <bits/stdc++.h>
using namespace std;
#define var auto
#define Max std::max
#define Min std::min

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#define fseek_unlocked fseek
#endif

inline int read()
{
    int x = 0;
    int k;
    while (true)
    {
        k = getchar_unlocked();
        if (k < '0') break;
        x = x * 10 + k - '0';
    }
    return x;
}

inline void writeline(int x) {
    int s = 0;
    char f[8];
    while (x)
    {
        f[s++] = x % 10;
        x /= 10;
    }
    while (s--)
        putchar_unlocked(f[s] + '0');
    putchar_unlocked('
');
}

int main()
{
    var n = read(), m = read(), d = read();
    int res = 0;
    int columnChain[100] = {};
    for (size_t i = 0; i < n; i++)
    {
        int currentChain = 0;
        for (size_t j = 0; j < m; j++)
        {
            if (getchar_unlocked() & 1)
            {
                res += Max(0, currentChain - d + 1);
                res += Max(0, columnChain[j] - d + 1);
                currentChain = 0;
                columnChain[j] = 0;
            }
            else
            {
                currentChain++;
                columnChain[j]++;
            }
        }
        res += Max(0, currentChain - d + 1);
        getchar_unlocked();
    }
    for (size_t i = 0; i < m; i++)
    {
        res += Max(0, columnChain[i] - d + 1);
    }
    writeline(res);
	return 0;
}
