// detail: https://atcoder.jp/contests/abc097/submissions/8973361
open System

[<EntryPoint>]
let main argv =
    let abcd = stdin.ReadLine().Split() |> Array.map int
    let a = abcd.[0]
    let b = abcd.[1]
    let c = abcd.[2]
    let d = abcd.[3]
    if (min ([|a - b; b - c|] |> Array.map abs |> Array.max) (abs (a - c))) <= d then "Yes" else "No"
    |> stdout.WriteLine
    0
