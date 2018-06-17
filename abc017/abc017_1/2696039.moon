// detail: https://atcoder.jp/contests/abc017/submissions/2696039
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
rscore = -> 
  inp = rsint!
  math.floor inp[1] * inp[2] / 10
print rscore! + rscore! + rscore!
