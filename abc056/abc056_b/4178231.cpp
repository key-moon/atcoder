// detail: https://atcoder.jp/contests/abc056/submissions/4178231
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int w,a,b;
	cin >> w >> a >> b;
	cout << max(0,abs(b - a) - w) << endl;
}
