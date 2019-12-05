// detail: https://atcoder.jp/contests/abc105/submissions/8798240
open System


[<EntryPoint>]
let main argv =
    let nk = Console.ReadLine().Split() |> Array.map int
    if nk.[0] % nk.[1] = 0 then 0 else 1
    |> Console.WriteLine
    0
