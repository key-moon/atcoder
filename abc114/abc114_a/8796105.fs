// detail: https://atcoder.jp/contests/abc114/submissions/8796105
open System

[<EntryPoint>]
let main argv =
    match Console.ReadLine() with
    | ("3" | "5" | "7") -> "YES"
    | _ -> "NO"
    |> Console.WriteLine
    0
