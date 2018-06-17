// detail: https://atcoder.jp/contests/chokudai_S001/submissions/2696056
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

tsum = (t) ->
  sum = 0
  for i in *t
    sum += i
  sum

io.read!
print tsum rsint!
