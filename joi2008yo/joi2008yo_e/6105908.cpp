// detail: https://atcoder.jp/contests/joi2008yo/submissions/6105908
#include <bits/stdc++.h>
using namespace std;

void scan(uint32_t& x)
{
	x = 0;
	int k;
	while (true)
	{
		k = getchar_unlocked();
		if (k < '0' || k > '9')	break;
		x = x * 10 + k - '0';
	}
}

template<size_t max_R>
struct Table
{
	uint32_t table[1 << max_R];
	constexpr Table(uint32_t R = 0) : table()
	{
		for (size_t i = 0; i < (1 << max_R); i++)
		{
			auto popcnt = popcount(i);
			table[i] = std::max(R - popcnt, popcnt);
		}
	}
	constexpr uint32_t popcount(uint32_t n)
	{
		n = n - ((n >> 1) & 0x55555555U);
		n = (n & 0x33333333U) + ((n >> 2) & 0x33333333U);
		return (((n + (n >> 4) & 0xF0F0F0FU) * 0x1010101U) >> 24);
	}
	constexpr uint32_t operator[](size_t i) const 
	{
		return table[i];
	}
};

template<size_t max_R>
struct Tables
{
	Table<max_R> table[max_R + 1];
	constexpr Tables() : table()
	{
		for (size_t R = 0; R <= max_R; R++)
		{
			table[R] = Table<max_R>(R);
		}
	}
	constexpr Table<max_R> operator[](size_t R) const
	{
		return table[R];
	}
};

int main() 
{
	Tables<10> tables = Tables<10>();
	uint32_t R, C;
	scan(R);
	scan(C);
	Table<10> table = tables[R];

	vector<uint16_t> columns(C, 0);
	for (size_t i = 0; i < R; i++)
	{
		for (size_t j = 0; j < C; j++)
		{
			columns[j] |= (getchar_unlocked() & 1) << i;
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
		max = std::max(max, res);
	}
	printf("%d
", max);
	return 0;
}
