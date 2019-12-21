// detail: https://atcoder.jp/contests/abc035/submissions/9044895
[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map double
    if (ab.[1] / ab.[0]) < 0.67 then "16:9" else "4:3"
    |> stdout.WriteLine
    0
