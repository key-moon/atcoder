// detail: https://atcoder.jp/contests/abc117/submissions/8795520
open System

[<EntryPoint>]
let main argv =
    let tx = Console.ReadLine().Split() |> Array.map double
    tx.[0] / tx.[1] |> Console.WriteLine
    0
