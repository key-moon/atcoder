// detail: https://atcoder.jp/contests/abc119/submissions/8795466
open System

[<EntryPoint>]
let main argv =
    let s = Console.ReadLine()
    if (int s.[5..6]) < 5 then "Heisei" else "TBD"
    |> Console.WriteLine
    0
