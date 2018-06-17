// detail: https://atcoder.jp/contests/abc002/submissions/2695930
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
tmax = (t) ->
  max = -1
  for i in *t
    max = math.max(max,i)
  max

input = rsint!
print tmax input
