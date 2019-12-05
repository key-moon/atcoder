// detail: https://atcoder.jp/contests/abc100/submissions/8798587
open System

[<EntryPoint>]
let main argv =
    if Console.ReadLine().Split() |> Array.forall (fun x -> (x |> int) <= 8) then "Yay!" else ":("
    |> Console.WriteLine
    0
