// detail: https://atcoder.jp/contests/abc120/submissions/8794968
open System

[<EntryPoint>]
let main argv =
    let abc = Console.ReadLine().Split() |> Array.map int
    min (abc.[1] / abc.[0]) (abc.[2])
    |> Console.WriteLine
    0
