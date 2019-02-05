// detail: https://atcoder.jp/contests/agc023/submissions/4178301
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int n;
	cin >> n;
	vector<int> a(n);
	rep(i,n) cin >> a[i];
	map<ll,ll> hoge;
	hoge[0]++;
	ll ruiseki = 0;
	for(auto&& item : a){
		ruiseki += item;
		hoge[ruiseki]++;
	}
	ll res = 0;
	for(auto&& item : hoge){
		res += item.second * (item.second - 1) / 2;
	}
	cout << res;
}
