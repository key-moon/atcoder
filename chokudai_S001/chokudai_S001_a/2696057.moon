// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2696057
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

tmax = (t) ->
  max = -1
  for i in *t
    max = math.max(max,i)
  max

io.read!
print tmax rsint!
