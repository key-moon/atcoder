// detail: https://atcoder.jp/contests/joisc2015/submissions/4188639
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(int i = 0; i < (n); i++)
using namespace std;
const ll inf = 1ll << 60;

int main(){
	int k,n,m;
	cin >> k >> m;
	string s;
	cin >> s;
	cin >> n;
	vector<vector<int>> ops(n,vector<int>(3));
	rep(i,n) cin >> ops[i][0] >> ops[i][1] >> ops[i][2];
	vector<int> place(k);
	rep(i,k) place[i] = i;
	for(int opind = n - 1;opind >= 0; opind--){
		//挿入区間中であれば、挿入部に移動
		//挿入区間後であれば、まいなす
		auto item = ops[opind];
		int length = (item[1] - item[0]);
		int insertb = item[2];
		ll inserte = item[2] + length - 1;
		rep(ind,k){
			auto i = place[ind];
			if(insertb > i) continue;
			if(i <= inserte){
				i = item[0] + (i - insertb);
			}
			else{
				i = i - length;
			}
			place[ind] = i;
		}
        //rep(i,k) cout << place[i] << " ";
        //cout << endl;
    }
    string resstr;
    rep(i,k) resstr+= s[place[i]];
	cout << resstr << endl;
}
