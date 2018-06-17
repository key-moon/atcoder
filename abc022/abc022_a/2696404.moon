// detail: https://atcoder.jp/contests/abc022/submissions/2696404
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
nst = rsint!
res = 0
w = io.read "*n"
judge = -> if nst[2] <= w and w <= nst[3]
  res += 1
judge!
for i = 2,nst[1]
  w += io.read "*n"
  judge!
print res
