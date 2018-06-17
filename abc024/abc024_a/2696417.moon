// detail: https://atcoder.jp/contests/abc024/submissions/2696417
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
abck = rsint!
st = rsint!
print (st[1] * abck[1] + st[2] * abck[2] - (st[1] + st[2] - abck[4] >= 0 and (st[1] + st[2]) * abck[3] or 0))
