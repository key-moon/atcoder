// detail: https://atcoder.jp/contests/joi2018ho/submissions/4197338
#include <bits/stdc++.h>
#define rep(i,n) for(int i = 0;i<(n);i++)
typedef long long ll;
using namespace std;

int main() {
	int n;
	cin >> n;
	vector<pair<ll,ll>> v(n);
	rep(i,n){
		ll a,b;
		cin >> a >> b;
		v[i] = make_pair(a,b);
	}
	sort(v.begin(),v.end(),[](pair<ll,ll> fp,pair<ll,ll> sp){
		return fp.first > sp.first;
	});
	//minimumは必ず今になるわけで、

//	if(n>5000) return 0;
//	ll max1 = 0;
//	rep(i,n){
//		ll sum = 0;
//		ll curm = v[i].first;
//		for(int j = i;j<n;j++){
//			sum += v[j].second;
//			max1 = max(max1,sum-(curm-v[j].first));
//		}
//	}
//	cout << max1 << endl;
//	return 0;
	ll allmax = 0;
	ll curmax = 0;
	ll last = v[0].first;
	rep(i,n){
		//自分が選ばれる場合の最大
		curmax = max(curmax - (last - v[i].first),0ll) + v[i].second;
		allmax = max(allmax,curmax);
		//選ばれないときはなにか。最大が開くだけだが、それでも良いのか？
		//最大が開くのであれば現状の最大を記録
		//降順ソートした真ん中はみつにしたい、それはそう
		//もし途中から強いのが発生するとき　いやそれは最初から来たほうが強いじゃん
		last = v[i].first;
	}
	cout << allmax << endl;
}
