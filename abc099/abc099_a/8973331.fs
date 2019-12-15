// detail: https://atcoder.jp/contests/abc099/submissions/8973331
open System

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    printfn "AB%s" (if n < 1000 then "C" else "D")
    0
