// detail: https://atcoder.jp/contests/abc014/submissions/2513781
#include <bits/stdc++.h>
using namespace std;
int main() {
  int a,b;
  cin >> a >> b;
  cout << (b - (a % b)) % b << endl;
}
