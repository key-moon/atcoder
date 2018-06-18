// detail: https://atcoder.jp/contests/abc052/submissions/2696911
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
print math.max a[1]*a[2],a[3]*a[4]
