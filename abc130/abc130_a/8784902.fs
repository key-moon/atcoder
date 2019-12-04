// detail: https://atcoder.jp/contests/abc130/submissions/8784902
open System

[<EntryPoint>]
let main argv =
    let xa = Console.ReadLine().Split() |> Array.map int
    let x, a = xa.[0], xa.[1]
    (if x < a then 0 else 10) |> Console.WriteLine 
    0
