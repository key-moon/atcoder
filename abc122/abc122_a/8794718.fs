// detail: https://atcoder.jp/contests/abc122/submissions/8794718
open System

[<EntryPoint>]
let main argv =
    let s = Console.ReadLine()
    match s with
    | "A" -> "T"
    | "T" -> "A"
    | "G" -> "C"
    | "C" -> "G"
    |> Console.WriteLine
    0
