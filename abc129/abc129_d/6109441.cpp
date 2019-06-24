// detail: https://atcoder.jp/contests/abc129/submissions/6109441
#include <bits/stdc++.h>
using namespace std;
//C++ as C#
#define var auto
#define Max std::max
#define Min std::min

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

void writeline(uint32_t x) {
	int s = 0;
	char f[8];
	while (x) {
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
	int h = read(), w = read();
	int columnAccum[2000] = {};
	int rowMax[2000] = {};
	int max = 0;
	for (int i = 0; i < h; i++)
	{
		int currentChain = 0;
		for (int j = 0; j < w; j++)
		{
			if (getchar_unlocked() & 1)
			{
				max = Max(max, columnAccum[j] + rowMax[j]);
				for (int k = j - 1; k >= j - currentChain; k--)
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
		for (int j = w - 1; j >= w - currentChain; j--)
			rowMax[j] = Max(rowMax[j], currentChain);
		getchar_unlocked();
	}
	for (size_t i = 0; i < w; i++)
		max = Max(max, columnAccum[i] + rowMax[i]);
	writeline(max - 1);
	return 0;
}
