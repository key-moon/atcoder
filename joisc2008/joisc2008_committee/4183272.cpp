// detail: https://atcoder.jp/contests/joisc2008/submissions/4183272
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

vector<int> parent;
vector<int> yaruki;
vector<vector<int>> child;

ll Max = 0;
ll solve(int root){
	ll res = yaruki[root];
	for(auto&& c : child[root]){
		res += solve(c);
	}
	Max = max(Max,res);
	return max(0ll,res);
}

int main(){
	int n;
	cin >> n;
	parent = vector<int>(n);
	yaruki = vector<int>(n);
	child = vector<vector<int>>(n,vector<int>(0));
	rep(i,n){
		int p,val;
		cin >> p >> val;
		parent[i] = p- 1;
		if(p) child[p - 1].push_back(i);
		yaruki[i] = val;
	}
	solve(0);
	if(Max == 0){
		Max = *max_element(yaruki.begin(),yaruki.end());
	}
	cout << Max << endl;
}
