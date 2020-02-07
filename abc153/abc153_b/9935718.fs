// detail: https://atcoder.jp/contests/abc153/submissions/9935718
let hn = stdin.ReadLine().Split() |> Array.map int
let (h, n) = (hn.[0], hn.[1])
if stdin.ReadLine().Split() |> Array.map int |> Array.sum >= h then "Yes" else "No"
|> stdout.WriteLine
