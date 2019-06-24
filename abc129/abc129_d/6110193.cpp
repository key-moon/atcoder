// detail: https://atcoder.jp/contests/abc129/submissions/6110193
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

inline uint16_t read()
{
	uint16_t x = 0;
	int k;
	while (true)
	{
		k = getchar_unlocked();
		if (k < '0') break;
		x = x * 10 + k - '0';
	}
	return x;
}

inline void writeline(uint16_t x) {
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

uint16_t rowMax[2000];
uint16_t columnAccum[2000];
int main()
{
	int h = read(), w = read();
	uint16_t max = 0;
	for (uint16_t i = 0; i < h; i++)
	{
		uint16_t currentChain = 0;
		for (uint16_t j = 0; j < w; j++)
		{
			if (getchar_unlocked() & 1)
			{
				max = std::max<uint16_t>(max, columnAccum[j] + rowMax[j]);
				for (uint16_t k = j - currentChain; k < j; k++)
					rowMax[k] = std::max<uint16_t>(rowMax[k], currentChain);
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
		for (uint16_t j = w - currentChain; j < w; j++)
			rowMax[j] = std::max<uint16_t>(rowMax[j], currentChain);
		getchar_unlocked();
	}
	for (uint16_t i = 0; i < w; i++)
		max = std::max<uint16_t>(max, columnAccum[i] + rowMax[i]);
	writeline(max - 1);
	return 0;
}
