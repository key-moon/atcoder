// detail: https://atcoder.jp/contests/abc149/submissions/9936863
let abk = stdin.ReadLine().Split() |> Array.map int64
let (a, b, k) = (abk.[0], abk.[1], abk.[2])
let (afterA, afterB) = if a < k then (0L, max 0L (b + a - k)) else (a - k, b)
printf "%d %d" afterA afterB
