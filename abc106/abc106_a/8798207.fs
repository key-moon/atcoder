// detail: https://atcoder.jp/contests/abc106/submissions/8798207
open System


[<EntryPoint>]
let main argv =
    let xy = Console.ReadLine().Split() |> Array.map int
    (xy.[0] - 1) * (xy.[1] - 1) |> Console.WriteLine
    0
