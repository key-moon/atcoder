// detail: https://atcoder.jp/contests/abc124/submissions/8794540
open System

[<EntryPoint>]
let main argv =
    let ab = Console.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    max ((max a b) * 2 - 1) (a + b) |> Console.WriteLine
    0
