// detail: https://atcoder.jp/contests/joi2013yo/submissions/4177371
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int n;
	cin >> n;
	vector<vector<int>> a(n, vector<int>(3, 0));
	vector<vector<int>> b(3, vector<int>(200, 0));
	rep(i, n) {
		cin >> a[i][0] >> a[i][1] >> a[i][2];
		b[0][a[i][0]]++;
		b[1][a[i][1]]++;
		b[2][a[i][2]]++;
	}
	for(auto&& item : a){
		int res = 0;
		rep(i,3) {
        	if(b[i][item[i]] == 1) res += item[i];
        }
		cout << res << endl;
	}
}
