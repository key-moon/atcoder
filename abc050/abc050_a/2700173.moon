// detail: https://atcoder.jp/contests/abc050/submissions/2700173
i = io.read!
s = [tonumber s for s in string.gmatch i,"%d+"]
p = [s for s in string.gmatch i,"[%+,%-]"]
a = s[1]
b = s[2]
print if p[1] == "+"
  a + b
else
  a - b
