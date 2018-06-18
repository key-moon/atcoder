// detail: https://atcoder.jp/contests/abc040/submissions/2696624
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
print math.min a[1] - a[2],a[2]-1
