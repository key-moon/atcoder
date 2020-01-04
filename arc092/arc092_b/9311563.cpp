// detail: https://atcoder.jp/contests/arc092/submissions/9311563
#include <bits/stdc++.h>
using namespace std;
using ll = long long;

int main() {
	int n;
	cin >> n;
	vector<int> a(n);
	vector<int> b(n);
	for (size_t i = 0; i < n; i++)
		cin >> a[i];
	for (size_t i = 0; i < n; i++)
		cin >> b[i];
	int res = 0;
	for (int i = 28; i >= 0; i--)
	{
		int dig = 0;
		int zeroCountA = 0;
		int zeroCountB = 0;
		for (size_t j = 0; j < n; j++)
		{
			if ((a[j] >> i & 1) == 0) zeroCountA++;
			if ((b[j] >> i & 1) == 0) zeroCountB++;
			a[j] &= ((1 << i) - 1);
			b[j] &= ((1 << i) - 1);
		}
		int oneCountA = n - zeroCountA;
		int oneCountB = n - zeroCountB;
		dig ^= (oneCountA & 1) * (zeroCountB & 1) ^ (zeroCountA & 1) * (oneCountB & 1);
		sort(a.begin(), a.end());
		sort(b.begin(), b.end());
		size_t bInd = 0;
		for (int aInd = n - 1; aInd >= 0; aInd--)
		{
			while (bInd < n && a[aInd] + b[bInd] < (1 << i))
				bInd++;
			dig ^= n - bInd;
		}
		res ^= (dig & 1) << i;
	}
	cout << res << endl;
}
