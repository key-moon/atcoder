// detail: https://atcoder.jp/contests/abc042/submissions/2696654
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
table.sort a
print if a[1] == 5 and a[2] == 5 and a[3] == 7
  "YES"
else
  "NO"
