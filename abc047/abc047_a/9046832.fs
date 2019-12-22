// detail: https://atcoder.jp/contests/abc047/submissions/9046832
[<EntryPoint>]
let main argv =
    let a = stdin.ReadLine().Split() |> Array.map int
    if (a |> Array.sum) = (a |> Array.max) * 2 then "Yes" else "No"
    |> stdout.WriteLine
    0
