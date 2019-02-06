// detail: https://atcoder.jp/contests/joi2015ho/submissions/4186389
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(int i = 0; i < (n); i++)
using namespace std;
const ll minf = -2147483648;

int main(){
	int n,m;
	cin >> n >> m;
	vector<int> imos(n,0);
	int last;
	cin >> last;
	last--;
	rep(i,m - 1){
		int a;
		cin >> a;
		a--;
		imos[min(last,a)]++;
		imos[max(last,a)]--;
		last = a;
	}
	ll res = 0;
	int curcount = imos[0];
	rep(i,n - 1){
		ll a,b,c;
		cin >> a >> b >> c;
		res += min(a * curcount,c + b * curcount);
		curcount += imos[i + 1];
	}
	cout << res << endl;
}
