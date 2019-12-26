// detail: https://atcoder.jp/contests/abc066/submissions/9139850
[<EntryPoint>]
let main argv =
    let nm = stdin.ReadLine().Split() |> Array.map int
    (nm |> Array.sum) - (nm |> Array.max)
    |> stdout.WriteLine
    0
