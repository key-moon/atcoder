// detail: https://atcoder.jp/contests/abc128/submissions/8785751
open System

[<EntryPoint>]
let main argv =
    let ap = Console.ReadLine().Split() |> Array.map int
    let a, p = ap.[0], ap.[1]
    (a * 3 + p) / 2 |> Console.WriteLine
    0
