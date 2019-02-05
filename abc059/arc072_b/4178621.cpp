// detail: https://atcoder.jp/contests/abc059/submissions/4178621
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	ll x,y;
	cin >> x >> y;
	cout << (abs(x - y) <= 1 ? "Brown" : "Alice") << endl;
}
