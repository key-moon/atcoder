// detail: https://atcoder.jp/contests/abc046/submissions/2696771
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
table.sort a
res = 3
if a[1] == a[2]
  res -= 1
if a[3] == a[2]
  res -= 1
print res
