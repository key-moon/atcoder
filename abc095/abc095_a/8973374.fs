// detail: https://atcoder.jp/contests/abc095/submissions/8973374
open System

[<EntryPoint>]
let main argv =
    700 + (stdin.ReadLine() |> Seq.where (fun x -> x = 'o') |> Seq.length) * 100
    |> stdout.WriteLine
    0
