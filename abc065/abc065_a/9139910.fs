// detail: https://atcoder.jp/contests/abc065/submissions/9139910
[<EntryPoint>]
let main argv =
    let xab = stdin.ReadLine().Split() |> Array.map int
    let x = xab.[0]
    let over = xab.[2] - xab.[1]
    if over <= 0 then "delicious" else if over <= x then "safe" else "dangerous"
    |> stdout.WriteLine
    0
