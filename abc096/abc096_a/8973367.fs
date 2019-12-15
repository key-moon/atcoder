// detail: https://atcoder.jp/contests/abc096/submissions/8973367
open System

[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    let a = ab.[0]
    let b = ab.[1]
    a + (if a <= b then 1 else 0) - 1
    |> stdout.WriteLine
    0
