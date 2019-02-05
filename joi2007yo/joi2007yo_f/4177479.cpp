// detail: https://atcoder.jp/contests/joi2007yo/submissions/4177479
//============================================================================
#include<bits/stdc++.h>
typedef long long ll;
#define rep(i, n) for(ll i = 0; i < (n); i++)
using namespace std;

int main(){
	int w,h;
	cin >> w >> h;
	vector<vector<int>> grid(h, vector<int>(w, 0));
	vector<vector<bool>> ng(h, vector<bool>(w, false));
	int n;
	cin >> n;
	rep(i,n){
		int x,y;
		cin >> x >> y;
		ng[y - 1][x - 1] = true;
	}
	grid[0][0] = 0;
	rep(i,w){
		if(ng[0][i]) break;
		grid[0][i] = 1;
	}
	for(ll i = 1; i < h; i++){
		if(!ng[i][0]) grid[i][0] = grid[i - 1][0];
        //cout << grid[i][0] << " ";
		for(ll j = 1; j < w; j++){
			if(!ng[i][j]) grid[i][j] = grid[i - 1][j] + grid[i][j - 1];
            //cout << grid[i][j] << " ";
		}
        //cout << endl;
	}
	cout << grid[h - 1][w - 1] << endl;
}
