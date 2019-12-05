// detail: https://atcoder.jp/contests/abc116/submissions/8795541
open System

[<EntryPoint>]
let main argv =
    let abc = Console.ReadLine().Split() |> Array.map int
    abc.[0] * abc.[1] / 2 |> Console.WriteLine
    0
