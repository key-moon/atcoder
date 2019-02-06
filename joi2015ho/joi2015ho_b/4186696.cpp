// detail: https://atcoder.jp/contests/joi2015ho/submissions/4186696
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(int i = 0; i < (n); i++)
using namespace std;
const ll minf = -2147483648;

int main(){
	int n;
	cin >> n;
	vector<int> cake(n);
	rep(i,n) cin >> cake[i];
	vector<ll> dp(n,0);
	//dp[begin] : 始点がそこのときに最大のスコア begin-end                                                                                                            (inclusive)の間が食べられている。
	for(int size = 2; size <= n; size += 2){
		//サイズsizeまで増やすよ。
		auto newdp = vector<ll>(n,0);
		rep(i,n){
			auto head = i;
			auto tail = (i + size - 3) % n;
			//現状iからのびてるやつの先頭と尻のさき
			auto headn = i == 0 ? n - 1 : i - 1;
			auto tailn = (i + size - 3 + 1) % n;

			auto headnn = headn == 0 ? n - 1 : headn - 1;
			auto tailnn = (i + size - 3 + 2) % n;

			//先頭を後ろにやった場合
			if(cake[headnn] < cake[tailn]){
				newdp[headn] = max(newdp[headn],dp[head] + cake[headn]);
			}
			else{
				newdp[headnn] = max(newdp[headnn],dp[head] + cake[headn]);
			}

			//後ろをさらに後ろにやった
			if(cake[headn] < cake[tailnn]){
				newdp[head] = max(newdp[head],dp[head] + cake[tailn]);
			}
			else{
				newdp[headn] = max(newdp[headn],dp[head] + cake[tailn]);
			}
		}
		//rep(out,n) cout << newdp[out] << " ";
		//cout << endl;
		dp.swap(newdp);
	}
	if(n % 2 == 1){
		rep(i,n){
			dp[i] += cake[(i == 0 ? n : i) - 1];
		}
	}
	auto max = *max_element(dp.begin(),dp.end());
	cout << max << endl;
}
