// detail: https://atcoder.jp/contests/abc039/submissions/9044798
[<EntryPoint>]
let main argv =
    let abc = stdin.ReadLine().Split() |> Array.map int
    (abc.[0] * abc.[1] + abc.[0] * abc.[2] + abc.[1] * abc.[2]) * 2
    |> stdout.WriteLine
    0
