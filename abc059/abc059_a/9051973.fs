// detail: https://atcoder.jp/contests/abc059/submissions/9051973
open System

[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map (fun x -> x |> Seq.head |> Char.ToUpper |> string)
    |> String.concat ""
    |> stdout.WriteLine
    0
