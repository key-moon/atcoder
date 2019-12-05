// detail: https://atcoder.jp/contests/abc110/submissions/8796423
open System


[<EntryPoint>]
let main argv =
    let abc = Console.ReadLine().Split() |> Array.map int
    (abc |> Array.sum) + (abc |> Array.max) * 9
    |> Console.WriteLine
    0
