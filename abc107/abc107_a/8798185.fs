// detail: https://atcoder.jp/contests/abc107/submissions/8798185
open System


[<EntryPoint>]
let main argv =
    let ni = Console.ReadLine().Split() |> Array.map int
    ni.[0] - ni.[1] + 1 |> Console.WriteLine
    0
