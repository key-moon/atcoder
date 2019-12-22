// detail: https://atcoder.jp/contests/abc057/submissions/9052002
[<EntryPoint>]
let main argv =
    (stdin.ReadLine().Split() |> Array.map int |> Array.sum) % 24
    |> stdout.WriteLine
    0
