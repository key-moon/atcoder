// detail: https://atcoder.jp/contests/abc094/submissions/4178441
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int n;
	cin >> n;
	vector<int> x(n);
	vector<int> sorted(n);
	rep(i,n) {
		cin >> x[i];
		sorted[i] = x[i];
	}
	sort(sorted.begin(),sorted.end());
	int med1 = sorted[n / 2 - 1];
	int med2 = sorted[n / 2];
	for(auto&& item : x){
		cout << (item <= med1 ? med2 : med1) << endl;
	}
}
