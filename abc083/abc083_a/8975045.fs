// detail: https://atcoder.jp/contests/abc083/submissions/8975045
[<EntryPoint>]
let main argv =
    let abcd = stdin.ReadLine().Split() |> Array.map int
    let left = abcd.[0] + abcd.[1]
    let right = abcd.[2] + abcd.[3]
    if left > right then "Left" else if left = right then "Balanced" else "Right"
    |> stdout.WriteLine
    0
