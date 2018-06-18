// detail: https://atcoder.jp/contests/abc054/submissions/2696957
s = (n) -> (n+11)%13
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
p = rsint!
a = s p[1]
b = s p[2]
print if a > b
  "Alice"
elseif a < b
  "Bob"
else
  "Draw"
