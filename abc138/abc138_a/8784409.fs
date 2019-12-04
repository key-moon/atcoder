// detail: https://atcoder.jp/contests/abc138/submissions/8784409
open System

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    let s = Console.ReadLine()
    (if 3200 <= n then s else "red") |> Console.WriteLine
    0
