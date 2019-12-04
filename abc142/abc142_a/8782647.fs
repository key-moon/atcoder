// detail: https://atcoder.jp/contests/abc142/submissions/8782647
open System


[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    ((n + 1) / 2 |> double) / (n |> double) |> Console.WriteLine
    0
