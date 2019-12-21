// detail: https://atcoder.jp/contests/abc030/submissions/9035169
[<EntryPoint>]
let main argv =
    let abcd = stdin.ReadLine().Split() |> Array.map double
    let takRate = abcd.[1] / abcd.[0]
    let aokRate = abcd.[3] / abcd.[2]
    if takRate > aokRate then "TAKAHASHI" else if takRate < aokRate then "AOKI" else "DRAW"
    |> stdout.WriteLine
    0
