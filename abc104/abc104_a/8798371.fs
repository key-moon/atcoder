// detail: https://atcoder.jp/contests/abc104/submissions/8798371
open System

[<EntryPoint>]
let main argv =
    let (|ABC|ARC|AGC|) x = if x < 1200 then ABC else if x < 2800 then ARC else AGC
    match Console.ReadLine() |> int with
    | ABC -> "ABC"
    | ARC -> "ARC"
    | AGC -> "AGC"
    |> Console.WriteLine
    0
