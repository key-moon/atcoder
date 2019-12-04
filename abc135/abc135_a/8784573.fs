// detail: https://atcoder.jp/contests/abc135/submissions/8784573
open System

[<EntryPoint>]
let main argv =
    let ab = Console.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    (if (a - b) % 2 = 0 then (a + b) / 2 |> string else "IMPOSSIBLE") |> Console.WriteLine
    0
