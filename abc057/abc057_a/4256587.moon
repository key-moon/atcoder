// detail: https://atcoder.jp/contests/abc057/submissions/4256587
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
ab = rsint!
print (ab[1] + ab[2]) % 24
