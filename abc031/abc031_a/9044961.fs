// detail: https://atcoder.jp/contests/abc031/submissions/9044961
[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map int
    max (ab.[0] * (ab.[1] + 1)) ((ab.[0] + 1) * ab.[1])
    |> stdout.WriteLine
    0
