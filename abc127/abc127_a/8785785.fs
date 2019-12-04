// detail: https://atcoder.jp/contests/abc127/submissions/8785785
open System

[<EntryPoint>]
let main argv =
    let ab = Console.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    (if a <= 5 then 0 else if a < 13 then b / 2 else b) |> Console.WriteLine
    0
