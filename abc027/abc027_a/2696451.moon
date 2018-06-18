// detail: https://atcoder.jp/contests/abc027/submissions/2696451
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
res = if a[1] == a[2]
  3
elseif a[1] == a[3]
  2
else
  1
print a[res]
