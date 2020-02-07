// detail: https://atcoder.jp/contests/abc151/submissions/9936456
let nkm = stdin.ReadLine().Split() |> Array.map int
let (n, k, m) = (nkm.[0], nkm.[1], nkm.[2])
let sum = stdin.ReadLine().Split() |> Array.map int |> Array.sum
let next = n * m - sum
if next <= k then max 0 next else -1
|> stdout.WriteLine
