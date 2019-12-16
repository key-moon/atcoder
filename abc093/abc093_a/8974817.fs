// detail: https://atcoder.jp/contests/abc093/submissions/8974817
open System

[<EntryPoint>]
let main argv =
    if (stdin.ReadLine() |> Seq.distinct |> Seq.length) = 3 then "Yes" else "No"
    |> stdout.WriteLine
    0
