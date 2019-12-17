// detail: https://atcoder.jp/contests/abc008/submissions/8994191
[<EntryPoint>]
let main argv =
    let xy = stdin.ReadLine().Split() |> Array.map int
    (xy.[1] - xy.[0] + 1) |> stdout.WriteLine
    0
