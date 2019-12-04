// detail: https://atcoder.jp/contests/abc125/submissions/8787685
open System

[<EntryPoint>]
let main argv =
    let abt = Console.ReadLine().Split() |> Array.map int
    let a, b, t = abt.[0], abt.[1], abt.[2]
    (t / a) * b |> Console.WriteLine
    0
