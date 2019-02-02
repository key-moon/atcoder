// detail: https://atcoder.jp/contests/abc108/submissions/4147050
#include <bits/stdc++.h>
using namespace std;

int main() {
	int x1,y1,x2,y2;
	cin >> x1 >> y1 >> x2 >> y2;
	int dirx = x2 - x1;
	int diry = y2 - y1;
	int x3 = x2 - diry;
	int y3 = y2 + dirx;
	int x4 = x3 - dirx;
	int y4 = y3 - diry;
	cout << x3 << " " << y3 << " " << x4 << " " << y4 << endl;
}
