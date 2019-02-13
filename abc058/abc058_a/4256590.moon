// detail: https://atcoder.jp/contests/abc058/submissions/4256590
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
abc = rsint!
print if (abc[2]-abc[1])==(abc[3]-abc[2])
  "YES"
else
  "NO"
