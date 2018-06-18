// detail: https://atcoder.jp/contests/abc044/submissions/2696749
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
n=io.read "*n"
k=io.read "*n"
x=io.read "*n"
y=io.read "*n"
print (math.min(n, k) * x + math.max(0, n - k) * y)
