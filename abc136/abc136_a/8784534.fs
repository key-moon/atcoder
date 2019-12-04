// detail: https://atcoder.jp/contests/abc136/submissions/8784534
open System

[<EntryPoint>]
let main argv =
    let abc = Console.ReadLine().Split() |> Array.map int
    let a, b, c = abc.[0], abc.[1], abc.[2]
    c + b - a |> max 0 |> Console.WriteLine
    0
