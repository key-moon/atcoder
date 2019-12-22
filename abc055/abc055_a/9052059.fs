// detail: https://atcoder.jp/contests/abc055/submissions/9052059
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    n * 800 - n / 15 * 200
    |> stdout.WriteLine
    0
