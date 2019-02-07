// detail: https://atcoder.jp/contests/joisc2015/submissions/4189103
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(int i = 0; i < (n); i++)
using namespace std;
const ll inf = 1ll << 60;

int main(){
	int n;
	cin >> n;
	//自分より前の数字によって生成可能な
	vector<int> a(n - 1);
	ll res = 1;
	ll need = -1;
	ll blankplace = -1;
	ll curmax = 0;
	ll blankcount = 0;
	rep(i,n - 1) {
		cin >> a[i];
		if(a[i] - curmax >= 2){
			need = curmax;
			blankplace = i;
			blankcount += (a[i] - curmax - 1);
		}
		if(curmax < a[i])	curmax = a[i];
		res--;
		res += (curmax + 1);
	}
	if(blankcount == 1){
		rep(i,n - 1){
			if(a[i] == need){
				cout << (blankplace - i) << endl;
				return 0;
			}
		}
		cout << 1 << endl;
		return 0;
	}
	if(blankcount >= 2){
		cout << 0 << endl;
		return 0;
	}
	cout << res << endl;
}
