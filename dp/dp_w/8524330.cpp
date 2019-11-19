// detail: https://atcoder.jp/contests/dp/submissions/8524330
#include <bits/stdc++.h>
using namespace std;

// 1-indexed
template <class T, class E>
struct SegmentTreeLaze {
  // a,b:T c,d:E e:E(unit)
  // g(f(a,b),c) = f(g(a,c),g(b,c))
  // g(g(a,c),d) = g(a,h(c,d))
  // g(a,e) = a
  typedef function<T(T, T)> F;
  typedef function<T(T, E)> G;
  typedef function<E(E, E)> H;
  int n, height;
  F f;
  G g;
  H h;
  T tunit;
  E eunit;
  vector<T> dat;
  vector<E> laz;
  SegmentTreeLaze(){};
  SegmentTreeLaze(int newn, F f, G g, H h, T nt, E ne)
      : f(f), g(g), h(h), tunit(nt), eunit(ne) {
    init(newn);
  }
  void init(int newn) {
    n = 1, height = 0;
    while(n < newn) n <<= 1, ++height;
    dat.assign(n << 1, tunit);
    laz.assign(n << 1, eunit);
  }

  inline T reflect(int k) {
    return laz[k] == eunit ? dat[k] : g(dat[k], laz[k]);
  }

  inline void eval(int k) {
    if(laz[k] == eunit) return;
    laz[k << 1] = h(laz[k << 1], laz[k]);
    laz[(k << 1) | 1] = h(laz[(k << 1) | 1], laz[k]);
    dat[k] = reflect(k);
    laz[k] = eunit;
  }

  inline void thrust(int k) {
    for(int i = height; i; --i) eval(k >> i);
  }

  void recalc(int k) {
    while(k >>= 1)
      dat[k] = f(reflect(k << 1), reflect((k << 1) | 1));
  }
  // [a,b)
  void update(int a, int b, E newdata) {
    thrust(a += n);
    thrust(b += n - 1);
    for(int l = a, r = b + 1; l < r; l >>= 1, r >>= 1) {
      if(l & 1) laz[l] = h(laz[l], newdata), l++;
      if(r & 1) --r, laz[r] = h(laz[r], newdata);
    }
    recalc(a);
    recalc(b);
  }

  void set_val(int k, T newdata) {
    thrust(k += n);
    dat[k] = newdata;
    laz[k] = eunit;
    recalc(k);
  }

  // [a,b)
  T query(int a, int b) {
    thrust(a += n);
    thrust(b += n - 1);
    T vl = tunit, vr = tunit;
    for(int l = a, r = b + 1; l < r; l >>= 1, r >>= 1) {
      if(l & 1) vl = f(vl, reflect(l++));
      if(r & 1) vr = f(reflect(--r), vr);
    }
    return f(vl, vr);
  }
};

struct data {
  long long l, r, a;
};

long long n, m;
map<long long, vector<data>> mp;

long long solve();

int main() {
  cin >> n >> m;
  for(int i = 0; i < m; ++i) {
    long long l, r, a;
    cin >> l >> r >> a;
    mp[r].push_back({l, r, a});
  }

  cout << solve() << endl;
  return 0;
}

long long solve() {
  auto f = [](long long l, long long r) {
    return max(l, r);
  };
  auto g = [](long long l, long long r) { return l + r; };
  auto h = [](long long l, long long r) { return l + r; };
  SegmentTreeLaze<long long, long long> dp(n, f, g, h, 0,
                                           0);
  for(int i = 1; i <= n; ++i) {
    dp.update(i - 1, i, dp.query(0, i));
    long long mpsize = mp[i].size();
    for(int j = 0; j < mpsize; ++j)
      dp.update(mp[i][j].l - 1, i, mp[i][j].a);
  }
  return dp.query(0, n);
}
