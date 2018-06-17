// detail: https://atcoder.jp/contests/abc081/submissions/2696370
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

tsum = (t) ->
  sum = 0
  for i in *t
    sum += i
  sum

input = io.read!
print (tonumber string.sub input,1,1) + (tonumber string.sub input,2,2) + (tonumber string.sub input,3,3)
