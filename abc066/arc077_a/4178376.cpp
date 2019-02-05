// detail: https://atcoder.jp/contests/abc066/submissions/4178376
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int n;
	cin>>n;
	list<int> l;
	rep(i,n){
		int a;
		cin >> a;
		if(i % 2 == n % 2) l.push_back(a);
		else l.push_front(a);
	}
	
	for(auto&& a : l){
		cout << a << " ";
	}
}
