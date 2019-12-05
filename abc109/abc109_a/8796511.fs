// detail: https://atcoder.jp/contests/abc109/submissions/8796511
open System


[<EntryPoint>]
let main argv =
    if Console.ReadLine() |> Seq.exists (fun x -> x = '2') then "No" else "Yes"
    |> Console.WriteLine
    0
