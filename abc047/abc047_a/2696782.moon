// detail: https://atcoder.jp/contests/abc047/submissions/2696782
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
table.sort a
print if a[1] + a[2] == a[3]
  "Yes"
else
  "No"
