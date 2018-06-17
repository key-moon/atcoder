// detail: https://atcoder.jp/contests/abc008/submissions/2696000
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]

input = rsint!
print input[2] - input[1] + 1
