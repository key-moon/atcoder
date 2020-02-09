// detail: https://atcoder.jp/contests/abc154/submissions/9999870
let n = stdin.ReadLine() |> int
if (stdin.ReadLine().Split() |> Array.distinct |> Array.length) = n then "YES" else "NO"
|> stdout.WriteLine
