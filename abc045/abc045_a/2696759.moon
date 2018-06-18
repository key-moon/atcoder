// detail: https://atcoder.jp/contests/abc045/submissions/2696759
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
a=io.read "*n"
b=io.read "*n"
h=io.read "*n"
print math.floor (a+b)*h/2
