// detail: https://atcoder.jp/contests/abc002/submissions/2714330
input = io.read!
len = string.len input
res = {}

for i = 1,len
  c = input.sub input,i,i
  if "a"!=c and "i"!=c and "u"!=c and "e"!=c and "o"!=c
    table.insert res,c

print table.concat res
