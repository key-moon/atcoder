// detail: https://atcoder.jp/contests/abc074/submissions/9035417
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    let a = stdin.ReadLine() |> int
    n * n - a
    |> stdout.WriteLine
    0
