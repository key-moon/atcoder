// detail: https://atcoder.jp/contests/joi2018ho/submissions/4196901
#include <bits/stdc++.h>
#define rep(i,n) for(int i = 0;i<(n);i++)
typedef long long ll;
using namespace std;

int main() {
	int n,k;
	cin >> n >> k;
	int start;
	cin >> start;
	int last = start;
	vector<int> dist(n-1);
	rep(i,n-1){
		int a;
		cin >> a;
		dist[i] = a - last - 1;
		last = a;
	}
	sort(dist.begin(),dist.end());
	int total = last-start+1;
	for(int i = n - 2;i>=n-k;i--){
		total-=dist[i];
	}
	cout << total << endl;
}
