// detail: https://atcoder.jp/contests/joi2008yo/submissions/6050979
#include <bits/stdc++.h>
using namespace std;

#ifdef NO_UNLOCK_IO
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#endif

void scan(uint32_t& x)
{
	x = 0;
	int k;
	while (true)
	{
		k = getchar();
		if (k < '0' || k > '9')	break;
		x = x * 10 + k - '0';
	}
}


int main() {
	uint32_t R, C;
	scan(R);
	scan(C);

	vector<uint16_t> columns(C, 0);
	for (size_t i = 0; i < R; i++)
	{
		for (size_t j = 0; j < C; j++)
		{
			columns[j] |= (getchar() & 1) << i;
			getchar();
		}
	}

	uint32_t table[1024];
	for (size_t i = 0; i < (1 << R); i++)
	{
		auto popcnt = __builtin_popcount(i);
		table[i] = std::max(R - popcnt, (uint32_t)popcnt);
	}

	uint32_t max = 0;
	for (uint16_t i = 0; i < (1 << R); i++)
	{
		uint32_t res = 0;
		for (size_t j = 0; j < C; j++)
		{
			res += table[columns[j] ^ i];
		}
		max = std::max(max, res);
	}
	printf("%d
", max);
	return 0;
}
