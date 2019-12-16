// detail: https://atcoder.jp/contests/abc091/submissions/8974868
[<EntryPoint>]
let main argv =
    let abx = stdin.ReadLine().Split() |> Array.map int
    let a = abx.[0]
    let b = abx.[1]
    let x = abx.[2]
    if x <= a + b then "Yes" else "No"
    |> stdout.WriteLine
    0
