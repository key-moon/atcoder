// detail: https://atcoder.jp/contests/abc126/submissions/8787657
open System

[<EntryPoint>]
let main argv =
    let nk = Console.ReadLine().Split() |> Array.map int
    let n, k = nk.[0], nk.[1] - 1
    let s = Console.ReadLine().ToCharArray()
    Array.set s k (s.[k] |> Char.ToLower)
    s |> Console.WriteLine
    0
