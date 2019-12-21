// detail: https://atcoder.jp/contests/abc036/submissions/9044872
[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    (ab.[1] + ab.[0] - 1) / ab.[0]
    |> stdout.WriteLine
    0
