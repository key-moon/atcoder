// detail: https://atcoder.jp/contests/joisc2014/submissions/4183667
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(int i = 0; i < (n); i++)
using namespace std;
const ll minf = -2147483648;

int main(){
	int n;
	cin >> n;
	//穴の数で配列取ってDP
	//穴がn個余っているときの最大happiness
	vector<vector<int>> v(n,vector<int>(2));
	rep(i,n){
		int a,b;
		cin >> a >> b;
		v[i][0] = a;
		v[i][1] = b;
	}
	sort(v.begin(),v.end(),[](const vector<int> &a,const vector<int> &b){
		return a[0] > b[0];
	});
	vector<ll> dp = vector<ll>(n * 2,minf);
	dp[1] = 0;
	for(auto&& item : v){
		auto newdp = dp;
		rep(i,n * 2){
			if((item[0] == 0 && i == 0) || newdp[i] == minf) continue;
			int ind = min(i + item[0] - 1, n * 2 - 1);
			newdp[ind] = max(dp[i] + item[1], newdp[ind]);
		}
		dp = newdp;
	}
	auto res = *max_element(dp.begin(),dp.end());
	cout << res << endl;
}
