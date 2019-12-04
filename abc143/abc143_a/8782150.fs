// detail: https://atcoder.jp/contests/abc143/submissions/8782150
open System


[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    Console.WriteLine (a - b * 2 |> max 0)
    0
