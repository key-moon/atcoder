// detail: https://atcoder.jp/contests/abc129/submissions/6110104
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

inline void read(uint32_t& x)
{
	x = 0;
	int k;
	while (true)
	{
		k = getchar_unlocked();
		if (k < '0') break;
		x = x * 10 + k - '0';
	}
}

void writeline(uint32_t x) {
	int s = 0;
	char f[4];
	while (x) {
		f[s++] = x % 10;
		x /= 10;
	}
	while (s--)
		putchar_unlocked(f[s] + '0');
	putchar_unlocked('
');
}

int rowMax[2000];
int columnAccum[2000];
int main()
{
	uint32_t h, w;
	read(h);
	read(w);
	int max = 0;
	for (size_t i = 0; i < h; i++)
	{
		int currentChain = 0;
		for (size_t j = 0; j < w; j++)
		{
			if (getchar_unlocked() & 1)
			{
				max = Max(max, columnAccum[j] + rowMax[j]);
				for (size_t k = j - currentChain; k < j; k++)
					rowMax[k] = Max(rowMax[k], currentChain);
				currentChain = 0;
				rowMax[j] = 0;
				columnAccum[j] = 0;
			}
			else
			{
				currentChain++;
				columnAccum[j]++;
			}
		}
		for (size_t j = w - currentChain; j < w; j++)
			rowMax[j] = Max(rowMax[j], currentChain);
		getchar_unlocked();
	}
	for (size_t i = 0; i < w; i++)
		max = Max(max, columnAccum[i] + rowMax[i]);
	writeline(max - 1);
	return 0;
}
