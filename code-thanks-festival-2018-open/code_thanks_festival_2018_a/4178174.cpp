// detail: https://atcoder.jp/contests/code-thanks-festival-2018-open/submissions/4178174
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int t,a,b,c,d;
	cin >> t >> a >> b >> c >> d;
	if(t >= a + c) cout << b + d << endl;
	else if(t >= a && t >= c) cout << max(b,d) << endl;
	else{
		if(t >= a) cout << b << endl;
		else if(t >= c) cout << d << endl;
		else cout << 0 << endl;
	}
}
