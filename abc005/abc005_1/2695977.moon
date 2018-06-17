// detail: https://atcoder.jp/contests/abc005/submissions/2695977
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

a = rsint!
print math.floor a[2] / a[1]
