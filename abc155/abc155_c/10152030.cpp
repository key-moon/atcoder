// detail: https://atcoder.jp/contests/abc155/submissions/10152030
#include <bits/stdc++.h>

#define var auto
#define long long long
#define ll long
#define Max std::max
#define Min std::min
#define Abs std::abs
using namespace std;

int main(){
	int n;
	cin >> n;
	map<string, int> count{};
	for (size_t i = 0; i < n; i++)
	{
		string s;
		cin >> s;
		count[s]++;
	}
	var max = 0;
	for (auto& i : count)
	{
		max = Max(max, i.second);
	}
	vector<string> res{};
	for (auto& i : count)
	{
		if (i.second == max) res.push_back(i.first);
	}
	sort(res.begin(), res.end());
	for (auto& i : res)
	{
		cout << i << endl;
	}
}
