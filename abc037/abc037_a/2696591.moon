// detail: https://atcoder.jp/contests/abc037/submissions/2696591
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
print math.floor(a[3]/math.min a[1],a[2])
