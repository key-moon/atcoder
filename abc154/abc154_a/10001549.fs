// detail: https://atcoder.jp/contests/abc154/submissions/10001549
let st = stdin.ReadLine().Split()
let ab = stdin.ReadLine().Split() |> Array.map int
let u = stdin.ReadLine()
if u = st.[0] then (ab.[0] - 1, ab.[1]) else (ab.[0], ab.[1] - 1)
|> (fun (a, b) -> printf "%d %d" a b)
