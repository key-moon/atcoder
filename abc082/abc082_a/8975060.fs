// detail: https://atcoder.jp/contests/abc082/submissions/8975060
[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split() |> Array.map double |> Array.average |> ceil |> stdout.WriteLine
    0
