// detail: https://atcoder.jp/contests/joi2008yo/submissions/6110365
#include <bits/stdc++.h>
using namespace std;

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#endif // VS


void scan(uint32_t& x)
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

void print(uint32_t x) {
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

template<size_t max_R>
struct Tables
{
	uint32_t table[max_R + 1][1 << max_R];
	constexpr Tables() : table()
	{
		for (size_t R = 0; R <= max_R; R++)
		{
			for (size_t i = 0; i < (1 << max_R); i++)
			{
				auto popcnt = popcount(i);
				table[R][i] = R - popcnt > popcnt ? R - popcnt : popcnt;
			}
		}
	}
	constexpr const uint32_t* operator[](size_t R) const
	{
		return table[R];
	}
	constexpr uint32_t popcount(uint32_t n)
	{
		n = n - ((n >> 1) & 0x55555555U);
		n = (n & 0x33333333U) + ((n >> 2) & 0x33333333U);
		return (((n + (n >> 4) & 0xF0F0F0FU) * 0x1010101U) >> 24);
	}

};


uint16_t columns[16384];
#pragma optimization_level 3
int main() 
{
	Tables<10> tables = Tables<10>();
	uint32_t R, C;
	scan(R);
	scan(C);
	const uint32_t* table = tables[R];

	for (size_t i = 0; i < R; i++)
	{
		for (size_t j = 0; j < C; j++)
		{
			columns[j] <<= 1;
			columns[j] |= (getchar_unlocked() & 1);
			getchar_unlocked();
		}
	}

	uint32_t max = 0;
	for (uint16_t i = 0; i < (1 << (R - 1)); i++)
	{
		uint32_t res = 0;
		for (size_t j = 0; j < C; j++)
		{
			res += table[columns[j] ^ i];
		}
		if (max < res) max = res;
	}
	print(max);
	return 0;
}
