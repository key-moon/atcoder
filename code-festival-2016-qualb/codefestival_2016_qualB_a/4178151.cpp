// detail: https://atcoder.jp/contests/code-festival-2016-qualb/submissions/4178151
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	string s;
	cin >> s;
	int res = 0;
	rep(i,16) if(s[i] != "CODEFESTIVAL2016"[i]) res++;
	cout << res << endl;
}
