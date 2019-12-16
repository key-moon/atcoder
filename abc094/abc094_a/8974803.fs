// detail: https://atcoder.jp/contests/abc094/submissions/8974803
open System

[<EntryPoint>]
let main argv =
    let abx = stdin.ReadLine().Split() |> Array.map int
    let a = abx.[0]
    let b = abx.[1]
    let x = abx.[2]
    if a <= x && x <= a + b then "YES" else "NO"
    |> stdout.WriteLine
    0
