// detail: https://atcoder.jp/contests/abc018/submissions/2696376
a = io.read "*n"
b = io.read "*n"
c = io.read "*n"
max = math.max(a,b,c)
min = math.min(a,b,c)
out = (n) -> 
  if n == max
    return 1
  if n == min
    return 3
  2
print out a
print out b
print out c
