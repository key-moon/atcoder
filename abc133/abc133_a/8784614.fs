// detail: https://atcoder.jp/contests/abc133/submissions/8784614
open System

[<EntryPoint>]
let main argv =
    let nab = Console.ReadLine().Split() |> Array.map int
    let n, a, b = nab.[0], nab.[1], nab.[2]
    min (n * a) b |> Console.WriteLine
    0
