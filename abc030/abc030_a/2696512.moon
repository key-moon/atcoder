// detail: https://atcoder.jp/contests/abc030/submissions/2696512
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
abcd = rsint!
param = (abcd[2] / abcd[1]) - (abcd[4] / abcd[3])
print if param < 0
  "AOKI"
elseif param > 0
  "TAKAHASHI"
else
  "DRAW"
