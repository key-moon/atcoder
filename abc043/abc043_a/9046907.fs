// detail: https://atcoder.jp/contests/abc043/submissions/9046907
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    n * (n + 1) / 2
    |> stdout.WriteLine
    0
