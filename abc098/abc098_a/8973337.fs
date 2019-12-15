// detail: https://atcoder.jp/contests/abc098/submissions/8973337
open System

[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    let a = ab.[0]
    let b = ab.[1]
    [a + b; a - b; a * b] |> List.max |> stdout.WriteLine
    0
