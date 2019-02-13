// detail: https://atcoder.jp/contests/abc059/submissions/4256600
rsstr = -> [string.upper(string.sub(s,1,1)) for s in string.gmatch io.read!,"%l+"]
abc = rsstr!
print abc[1]..abc[2]..abc[3]
