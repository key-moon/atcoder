// detail: https://atcoder.jp/contests/abc086/submissions/2696362
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

tsum = (t) ->
  sum = 0
  for i in *t
    sum += i
  sum

input = rsint!
print switch (input[1] * input[2]) % 2
  when 0
    "Even"
  else
    "Odd"
