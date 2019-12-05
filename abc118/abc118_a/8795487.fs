// detail: https://atcoder.jp/contests/abc118/submissions/8795487
open System

[<EntryPoint>]
let main argv =
    let ab = Console.ReadLine().Split() |> Array.map int
    if ab.[1] % ab.[0] = 0 then (ab |> Array.sum) else ab.[1] - ab.[0] 
    |> Console.WriteLine
    0
