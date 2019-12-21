// detail: https://atcoder.jp/contests/abc076/submissions/9035442
[<EntryPoint>]
let main argv =
    let r = stdin.ReadLine() |> int
    let g = stdin.ReadLine() |> int
    g * 2 - r
    |> stdout.WriteLine
    0
