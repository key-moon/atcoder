// detail: https://atcoder.jp/contests/donuts-live2014/submissions/9263768
#include <bits/stdc++.h>
using ll = long long;

#ifdef _MSC_VER
#define getchar_unlocked getchar
#define putchar_unlocked putchar
#endif // VS

void read(uint32_t& x)
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

void sread(int32_t& x)
{
	bool flag;
	x = 0;
	int k = getchar_unlocked();
	if (flag = (k == '-')) k = getchar_unlocked();
	
	while (true)
	{
		if (k < '0' || k > '9')	break;
		x = x * 10 + k - '0';
		k = getchar_unlocked();
	}
	if (flag) x *= -1;
}

void sprint(int32_t x) {
	if (x == 0) {
		putchar_unlocked('0');
		return;
	}
	if (x < 0) {
		putchar_unlocked('-');
		x *= -1;
	}
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

int main() {
	uint32_t n;
	read(n);
	n--;
	int32_t res = INT32_MIN;
	int32_t min = 0;
	int32_t current = 0;
	sread(current);
	res = current;
	if (current < 0) min = current;
	while (n--)
	{
		int32_t a;
		sread(a);
		current += a;
		auto diff = current - min;
		if (res < diff) res = diff;
		else min = std::min(min, current);
	}
	sprint(res);
}
