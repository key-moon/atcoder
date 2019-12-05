// detail: https://atcoder.jp/contests/abc123/submissions/8794700
open System

[<EntryPoint>]
let main argv =
    let a = Console.ReadLine() |> int
    let b = Console.ReadLine() |> int
    let c = Console.ReadLine() |> int
    let d = Console.ReadLine() |> int
    let e = Console.ReadLine() |> int
    let k = Console.ReadLine() |> int
    if (e - a) <= k then "Yay!" else ":("
    |> Console.WriteLine
    0
