// detail: https://atcoder.jp/contests/abc129/submissions/8784961
open System

[<EntryPoint>]
let main argv =
    let pqr = Console.ReadLine().Split() |> Array.map int
    (pqr |> Array.sum) - (pqr |> Array.max) |> Console.WriteLine
    0
