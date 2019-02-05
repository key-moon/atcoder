// detail: https://atcoder.jp/contests/agc011/submissions/4178581
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int n;
	cin >> n;
	//なんか
	vector<int> a(n);
	rep(i,n) cin >> a[i];
	sort(a.begin(),a.end());
	ll ruiseki = 0;
	int lastng = 0;
	rep(i,n){
		if(ruiseki * 2 < a[i]) lastng = i;
		ruiseki += a[i];
	}
	cout << n - lastng << endl;
}
