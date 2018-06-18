// detail: https://atcoder.jp/contests/abc028/submissions/2696458
input = io.read "*n"
print if input <= 59
  "Bad"
elseif input <= 89
  "Good"
elseif input <= 99
  "Great"
else
  "Perfect"
