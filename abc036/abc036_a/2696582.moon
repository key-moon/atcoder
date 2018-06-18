// detail: https://atcoder.jp/contests/abc036/submissions/2696582
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
print math.ceil a[2] /a[1]
