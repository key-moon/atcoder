// detail: https://atcoder.jp/contests/abc019/submissions/2696381
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

input = rsint!
table.sort input
print input[2]
