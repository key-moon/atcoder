// detail: https://atcoder.jp/contests/abc108/submissions/8798120
open System


[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    (n / 2) * (n - n / 2) |> Console.WriteLine
    0
