// detail: https://atcoder.jp/contests/abc113/submissions/8796158
open System

[<EntryPoint>]
let main argv =
    let xy = Console.ReadLine().Split() |> Array.map int
    xy.[0] + (xy.[1] / 2) |> Console.WriteLine
    0
