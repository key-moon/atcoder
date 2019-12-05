// detail: https://atcoder.jp/contests/abc103/submissions/8798454
open System

[<EntryPoint>]
let main argv =
    let abc = Console.ReadLine().Split() |> Array.map int
    (abc |> Array.max) - (abc |> Array.min) |> Console.WriteLine
    0
