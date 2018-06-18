// detail: https://atcoder.jp/contests/abc034/submissions/2696550
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
ab = rsint!
print if ab[1] < ab[2]
  "Better"
else
  "Worse"
