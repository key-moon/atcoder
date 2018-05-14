// detail: https://atcoder.jp/contests/abc093/submissions/2513832
#include <bits/stdc++.h>
using namespace std;
int main() {
  string s;
  cin >> s;
  cout << ((s == "abc" || s == "acb" || s == "bac" || s == "bca" || s == "cab" || s == "cba")?"Yes":"No") << endl;
}
