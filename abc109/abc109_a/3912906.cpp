// detail: https://atcoder.jp/contests/abc109/submissions/3912906
#include <iostream>
#include <cstdio>
#include <cstdint>
#include <algorithm>
#include <vector>
#include <queue>
#include <utility>
using namespace std;
typedef	long long ll;

int main() {
	ll a,b;
	cin >> a >> b;
	cout << (((a * b) % 2 != 0) ? "Yes" : "No") << endl;
}
