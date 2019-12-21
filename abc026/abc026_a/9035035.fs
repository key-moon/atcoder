// detail: https://atcoder.jp/contests/abc026/submissions/9035035
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    n / 2 * (n - n / 2) |> stdout.WriteLine
    0
