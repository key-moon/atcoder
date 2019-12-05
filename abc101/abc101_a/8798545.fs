// detail: https://atcoder.jp/contests/abc101/submissions/8798545
open System

[<EntryPoint>]
let main argv =
    let count c seq = 
        Seq.filter (fun x -> x = c) seq
        |> Seq.length
    let s = Console.ReadLine()
    (s |> count '+') - (s |> count '-')
    |> Console.WriteLine
    0
