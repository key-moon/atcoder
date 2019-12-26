// detail: https://atcoder.jp/contests/abc067/submissions/9139825
[<EntryPoint>]
let main argv =
    let nm = stdin.ReadLine().Split() |> Array.map int
    let isValid n = n % 3 = 0
    if nm |> Array.exists isValid || (nm |> Array.sum |> isValid) then "Possible" else "Impossible"
    |> stdout.WriteLine
    0
