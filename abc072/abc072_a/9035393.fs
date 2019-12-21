// detail: https://atcoder.jp/contests/abc072/submissions/9035393
[<EntryPoint>]
let main argv =
    let xt = stdin.ReadLine().Split() |> Array.map int
    let x = xt.[0]
    let t = xt.[1]
    max 0 (x - t)
    |> stdout.WriteLine
    0
