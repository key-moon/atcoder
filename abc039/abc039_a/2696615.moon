// detail: https://atcoder.jp/contests/abc039/submissions/2696615
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a = rsint!
print (a[1]*a[2]+a[1]*a[3]+a[2]*a[3])*2
