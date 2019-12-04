// detail: https://atcoder.jp/contests/abc144/submissions/8782127
open System


[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    Console.WriteLine (if a < 10 & b < 10 then a * b else -1)
    0
