// detail: https://atcoder.jp/contests/abc005/submissions/8994136
[<EntryPoint>]
let main argv =
    let xy = stdin.ReadLine().Split() |> Array.map int
    (xy.[1] / xy.[0]) |> stdout.WriteLine
    0
