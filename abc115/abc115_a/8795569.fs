// detail: https://atcoder.jp/contests/abc115/submissions/8795569
open System

[<EntryPoint>]
let main argv =
    "Christmas" + (" Eve" |> String.replicate (25 - (Console.ReadLine() |> int)))
    |> Console.WriteLine
    0
