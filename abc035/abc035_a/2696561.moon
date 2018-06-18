// detail: https://atcoder.jp/contests/abc035/submissions/2696561
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
asp = rsint!
print if (asp[2] / asp[1]) == 0.75
  "4:3"
else
  "16:9"
