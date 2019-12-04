// detail: https://atcoder.jp/contests/abc137/submissions/8784437
open System

[<EntryPoint>]
let main argv =
    let ab = Console.ReadLine().Split() |> Array.map int
    let a, b = ab.[0], ab.[1]
    [|a + b; a - b; a * b|] |> Array.max |> Console.WriteLine
    0
