// detail: https://atcoder.jp/contests/abc023/submissions/2696409
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

tsum = (t) ->
  sum = 0
  for i in *t
    sum += i
  sum

input = io.read!
print (tonumber string.sub input,1,1) + (tonumber string.sub input,2,2) 
