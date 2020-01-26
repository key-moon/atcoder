// detail: https://atcoder.jp/contests/abc153/submissions/9758375
#include <bits/stdc++.h>

#define var auto
#define long long long
using namespace std;

int main() {
	ios::sync_with_stdio(false);
	cin.tie(nullptr);

	int h, n;
	cin >> h >> n;

	vector<long> attacks(h + 1, LONG_MAX / 2);
	for (size_t i = 0; i < n; i++)
	{
		int a, b;
		cin >> a >> b;
		long mag = 0;
		for (size_t j = 0; j < h + 1; j += a)
		{
			attacks[j] = min(attacks[j], mag);
			mag += b;
		}
		attacks[h] = min(attacks[h], mag);
	}
	vector<long> res(h + 1, LONG_MAX / 2);
	res[0] = 0;
	for (size_t power = 0; power < h + 1; power++)
	{
		var magic = attacks[power];
		for (int j = h; j >= h + 1 - power; j--)
		{
			res[h] = min(res[h], res[j] + magic);
		}
		for (int j = h - power; j >= 0; j--)
		{
			res[j + power] = min(res[j + power], res[j] + magic);
		}
	}
	cout << res[h] << endl;
}
